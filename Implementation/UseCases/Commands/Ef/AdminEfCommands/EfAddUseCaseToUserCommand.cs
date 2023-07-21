using Application.Exceptions;
using Application.UseCases.Commands.AdminCommands;
using Application.UseCases.Dto;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Ef.AdminEfCommands
{
    public class EfAddUseCaseToUserCommand : EfUseCase, IAddUseCaseToUserCommand
    {
        public EfAddUseCaseToUserCommand(Asp2023DbContext context) : base(context)
        {
        }

        public int Id => 3;

        public string Name => "Dodaj UseCase Useru";

        public string Description => "";

        public void Execute(CreateUserUseCasesDto data)
        {
            var userToFind = Context.Users.Find(data.UserId);

            if (userToFind == null)
            {
                throw new EntityNotFoundException("Users", data.UserId);
            }
            else
            {
                var ifAlreadyExists = Context.AllUserUseCases
                    .Where(x => x.UserId == data.UserId && x.UseCaseId == data.UseCaseId).FirstOrDefault();

                if(ifAlreadyExists != null)
                {
                    throw new AlreadyExistsException(this.Name);
                }
            }

            Context.AllUserUseCases.Add(new AllUserUseCase
            {
                UseCaseId= data.UseCaseId,
                UserId = data.UserId
            });

            Context.SaveChanges();
        }
    }
}
