using Application.Emails;
using Application.Exceptions;
using Application.UseCases.Commands;
using Application.UseCases.Dto;
using Azure.Core;
using DataAccess;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Ef
{
    public class EfRegisterUserCommand : EfUseCase, IRegisterUserCommand
    {
        private RegisterUserValidator Validator { get; }
        private IEmailSender _sender { get; }


        //Iz api dependency containera dobijamo takodje i u implementacionom sloju podatke koje smo definisali u dpc
        public EfRegisterUserCommand(Asp2023DbContext context, RegisterUserValidator validator, IEmailSender sender) : base(context)
        {
            Validator = validator;
            _sender = sender;
        }

        public int Id => 1;

        public string Name => "Registrovanje";

        public string Description => "";

        public void Execute(RegisterUserDto dto)
        {

            Validator.ValidateAndThrow(dto);   //Okida se middleware posle 

            var identityNumberToInsert = dto.IdentityNumber == null ? null : dto.IdentityNumber;
            var phoneNumberToInsert = dto.PhoneNumber == null ? null : dto.PhoneNumber;
            
            int roleIdToInsert = Context.Roles.Where(x => x.NameRole == "Korisnik").First().Id;

            var hash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            var userToAdd = new Domain.User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Password = hash,
                IdentityNumber = identityNumberToInsert,
                PhoneNumber = phoneNumberToInsert,
                RoleId = roleIdToInsert
            };

            //Context.Users.Add( userToAdd );
            //Context.SaveChanges();

            //int lastInsertedId = userToAdd.Id;

            var defaultUseCasesToAdd = 
                Context.UseCaseRoles.Where(x => x.RoleId == roleIdToInsert)
                                    .Select(x=>x.UseCaseId).ToList();

            var useCasesToAdd = new List<Domain.AllUserUseCase>();

            foreach (var oneRowId in defaultUseCasesToAdd)
            {
                useCasesToAdd.Add(new Domain.AllUserUseCase
                {
                    UseCaseId = oneRowId,
                    User = userToAdd
                });
            }


            userToAdd.AllUserUseCases = useCasesToAdd;

            Context.Users.Add(userToAdd);


            _sender.Send(new MailMessageDto
            {
                To = userToAdd.Email,
                Title = "You Registered .",
                Body = "< html > " +
                       "<head>" +
                       "<style>" +
                       "body { font-family: Arial, sans-serif; }" +
                       ".container { max-width: 600px; margin: 0 auto; padding: 20px; }" +
                       "h1 { color: #333; text-align: center; }" +
                       "p { margin-bottom: 20px; }" +
                       "table { width: 100%; border-collapse: collapse; }" +
                       "th, td { padding: 10px; border: 1px solid #ccc; }" +
                       "</style>" +
                       "</head>" +
                       "<body>" +
                       "<div class=\"container\">" +
                       "<h1>Dobrodošli!</h1>" +
                       "<p>Hvala vam što ste se registrovali. Evo informacija o vašoj registraciji:</p>" +
                       "<table>" +
                       "<tr>" +
                       "<th>Ime</th>" +
                       "<td>" + userToAdd.FirstName + "</td>" +
                       "</tr>" +
                       "<tr>" +
                       "<th>Prezime</th>" +
                       "<td>" + userToAdd.LastName + "</td>" +
                       "</tr>" +
                       "<tr>" +
                       "<th>Email</th>" +
                       "<td>" + userToAdd.Email + "</td>" +
                       "</tr>" +
                       "<tr>" +
                       "<th>Registrovan</th>" +
                       "<td>" + userToAdd.CreatedAt + "</td>" +
                       "</tr>" +
                       "</table>" +
                       "</div>" +
                       "</body>" +
                       "</html>"
            });



            Context.SaveChanges();


        }
    }
}
