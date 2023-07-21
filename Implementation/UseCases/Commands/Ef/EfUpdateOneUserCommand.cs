using Application;
using Application.Exceptions;
using Application.UseCases.Commands.AdminCommands;
using Application.UseCases.Dto;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Ef
{
    public class EfUpdateOneUserCommand : EfUseCase, IUpdateOneUserCommand
    {
        private IApplicationUser User { get; }
        private UpdateUserValidator Validator { get; }
        public EfUpdateOneUserCommand(Asp2023DbContext context,
            IApplicationUser user, UpdateUserValidator validator) : base(context)
        {
            User = user;
            Validator = validator;
        }

        public int Id => 27;

        public string Name => "Izmena Usera";

        public string Description => "User i Adminisitrator mogu da izbvrse ovo, samo sto user ne moze sam sebi uloge.";

        public void Execute(UpdateOneUserDto data)
        {

            bool havePermission = Context.AllUserUseCases.Where(x => x.UserId == User.Id && x.UseCaseId == this.Id).Any();

            var havePermissionForChangeRole = Context.Users.Include(x => x.Role)
                        .Where(x => x.Id == User.Id).First();

            var nameRole = havePermissionForChangeRole.Role.NameRole;  //NameRole 

            if (nameRole != "Administrator")
            {
                if (User.Id!=data.IdUserToUpdate)
                {
                    throw new ForbiddenExecutionException(this.Name, User.Identity);
                }
            }

            //provera 
            var toUpdate = new UpdateOneUserDto
            {
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
                IdentityNumber = data.IdentityNumber,
                PhoneNumber = data.PhoneNumber,
            };

            if (!string.IsNullOrEmpty(data.Password)) toUpdate.Password = data.Password;  //Skoro nikad nece stizati sa fronta jer ne moze da se desifruje BCrpyt
            
            Validator.ValidateAndThrow(toUpdate);

            var hash = BCrypt.Net.BCrypt.HashPassword(data.Password);

            var objToUpdate = Context.Users.Where(x => x.Id == data.IdUserToUpdate)
                            .Include(x => x.AllUserUseCases).FirstOrDefault();

            if (objToUpdate!=null && objToUpdate.Email != data.Email)
            {
                var isReserved = Context.Users.Where(x => x.Email == data.Email).Any();
                if (isReserved)
                {
                    throw new EmailExistsInDatabaseException(); 
                }
            }

            if (objToUpdate == null)
            {
                throw new EntityNotFoundException("Users", data.IdUserToUpdate);
            }


            var isExisToSet = Context.Roles.Find(data.RoleId);

            if (objToUpdate != null)
            {
                objToUpdate.FirstName = data.FirstName;
                objToUpdate.LastName = data.LastName;
                objToUpdate.Email = data.Email;
                if (!string.IsNullOrEmpty(data.Password)) objToUpdate.Password = hash;  //ako nije menjana sifra
                if (!string.IsNullOrEmpty(data.IdentityNumber)) objToUpdate.IdentityNumber = data.IdentityNumber;
                if (!string.IsNullOrEmpty(data.PhoneNumber)) objToUpdate.PhoneNumber = data.PhoneNumber;
                objToUpdate.IsActive = data.IsActive;

/*                if (data.RoleId != 0 && isExisToSet!= null)
                {
                    objToUpdate.RoleId = data.RoleId;
                }*/
            }

            //AllUserUseCases= InsertNewUseCases(newUserCases)





            if (nameRole == "Administrator" && isExisToSet != null && isExisToSet.Id != 0)
            {

                if (objToUpdate == null)
                {
                    throw new EntityNotFoundException("Users", data.IdUserToUpdate);
                }

                if (isExisToSet == null)
                {
                    throw new EntityNotFoundException("Roles", data.RoleId);
                }

                var newUserCases = Context.UseCaseRoles.Where(x => x.RoleId == data.RoleId).Select(x => x.UseCaseId);

                var toRemoveOldUseCases = Context.AllUserUseCases.Where(x => x.UserId == data.IdUserToUpdate).ToList();
                Context.AllUserUseCases.RemoveRange(toRemoveOldUseCases);

                var userUseCases = newUserCases.Select(x => new AllUserUseCase
                {
                    UserId = objToUpdate.Id,
                    UseCaseId = x
                }).ToList();

                objToUpdate.AllUserUseCases = userUseCases;

                if (data.RoleId != 0)
                {
                    var roleToUpdate = Context.Roles.Find(data.RoleId);
                    if (roleToUpdate == null)
                    {
                        throw new EntityNotFoundException("Roles", data.RoleId);
                    }

                    objToUpdate.RoleId = data.RoleId;
                }
            }
            // u suprotnom se nece menjati role



            Context.SaveChanges();
 

        }

    }
}
