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
    public class EfDeleteUseCaseUserCommand : EfUseCase, IDeleteUseCaseUserCommand
    {
        public EfDeleteUseCaseUserCommand(Asp2023DbContext context) : base(context)
        {
        }

        public int Id => 6;

        public string Name => "Obrisi use Case Useru";

        public string Description => "";

        public void Execute(DeleteUserUseCasesDto data)
        {
            var userToFind = Context.Users.Find(data.UserId);

            if (userToFind == null)
            {
                throw new EntityNotFoundException("Users", data.UserId);
            }

            var objToDelete= Context.AllUserUseCases.Where(x => x.UseCaseId == data.UseCaseId &&
                                               x.UserId == data.UserId).FirstOrDefault();

            if(objToDelete == null)
            {
                throw new DeleteButNotExistsErrorException();
            }

            Context.AllUserUseCases.Remove(objToDelete);

            Context.SaveChanges();
        }
    }
}
