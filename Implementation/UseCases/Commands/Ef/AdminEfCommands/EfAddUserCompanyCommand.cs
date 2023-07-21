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
    public class EfAddUserCompanyCommand : EfUseCase, IAddUserCompanyCommand
    {
        public EfAddUserCompanyCommand(Asp2023DbContext context) : base(context)
        {

        }

        public int Id => 12;

        public string Name => "Dodaj Usera Kompaniji";

        public string Description => "";

        public void Execute(UserCompanyDto data)
        {

            var companyToFind = Context.Companies.Find(data.CompanyId);
            if (companyToFind == null)
            {
                throw new EntityNotFoundException("Companies", data.CompanyId);
            }

            var userToFind = Context.Users.Find(data.UserId);
            if (userToFind == null)
            {
                throw new EntityNotFoundException("Users", data.UserId);
            }

            var ifAlreadyExists = Context.UserCompanies
                    .Where(x => x.UserId == data.UserId && x.CompanyId == data.CompanyId).FirstOrDefault();

            if (ifAlreadyExists != null)
            {
                throw new AlreadyExistsException(this.Name);
            }

            var toAdd = new Domain.UserCompany
            {
                UserId = data.UserId,
                CompanyId = data.CompanyId,
                CreatedAt=DateTime.Now
            };

            Context.UserCompanies.Add(toAdd);

            Context.SaveChanges();


        }
    }
}
