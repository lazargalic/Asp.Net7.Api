using Application.Exceptions;
using Application.UseCases.Commands.AdminCommands;
using Application.UseCases.Dto;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Ef.AdminEfCommands
{
    public class EfDeleteUseCaseToRoleCommand : EfUseCase, IDeleteUseCaseToRoleCommand
    {
        public EfDeleteUseCaseToRoleCommand(Asp2023DbContext context) : base(context)
        {
        }

        public int Id => 5;

        public string Name => "Obrisi Rolu Iz uloge";

        public string Description => "";

        public void Execute(DeleteUseCasesToRoleDto data)
        {
            try
            {
                var roleToFind = Context.Roles.Find(data.RoleId);

                if (roleToFind == null)
                {
                    throw new EntityNotFoundException("Roles", data.RoleId);
                }

                var ifAlreadyExists = Context.UseCaseRoles
                        .Where(x => x.RoleId == data.RoleId && x.UseCaseId == data.UseCaseId).FirstOrDefault();

                if (ifAlreadyExists == null)
                {
                    throw new DeleteButNotExistsErrorException();
                }

                Context.UseCaseRoles.Remove(ifAlreadyExists);

                //Sad treba svim korisnicima koji imaju tu Rolu da uklonimo taj useCaseId za tu Rolu, ista stvar kao i kada sam dodavao u operaciji EfAddUseCaseToRole, napisao sam tamo sta sam zeleo da postignem.

                int idRole = roleToFind.Id;

                var allUsersIdsWithThisRole = Context.Users.Where(x => x.RoleId == idRole).Select(x => x.Id).ToList();

                var objectsToDelete =
                    Context.AllUserUseCases.Where(x => x.UseCaseId == data.UseCaseId &&
                                                     allUsersIdsWithThisRole.Contains(x.UserId));

                foreach (var obj in objectsToDelete)
                {
                    Context.AllUserUseCases.Remove(obj);
                }

                Context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new ConflictInExecution("user", this.Name);
            }

        }
    }
}
