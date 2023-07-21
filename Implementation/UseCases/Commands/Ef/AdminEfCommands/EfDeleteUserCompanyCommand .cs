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
    public class EfDeleteUserCompanyCommand : EfUseCase, IDeleteUserCompanyCommand
    {
        public EfDeleteUserCompanyCommand(Asp2023DbContext context) : base(context)
        {
        }

        public int Id => 13;

        public string Name => "Obrisi Usera Kompaniji";

        public string Description => "";

        public void Execute(UserCompanyDto data)
        {
            var userToFind = Context.Users.Find(data.UserId);
            if (userToFind == null)
            {
                throw new EntityNotFoundException("Users", data.UserId);
            }

            var companyToFind = Context.Companies.Find(data.CompanyId);
            if (companyToFind == null)
            {
                throw new EntityNotFoundException("Companies", data.CompanyId);
            }

            var objToDelete = Context.UserCompanies.Where(x => x.CompanyId == data.CompanyId &&
                                               x.UserId == data.UserId).FirstOrDefault();

            if (objToDelete == null)
            {
                throw new DeleteButNotExistsErrorException();
            }

            Context.UserCompanies.Remove(objToDelete);

            Context.SaveChanges();
        }
    }
}
