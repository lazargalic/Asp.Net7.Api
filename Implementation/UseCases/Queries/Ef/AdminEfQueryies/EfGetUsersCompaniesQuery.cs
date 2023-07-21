using Application.UseCases.Dto;
using Application.UseCases.Queries.AdminQueries;
using Application.UseCases.Queries.Searches;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.Ef.AdminEfQueryies
{
    public class EfGetUsersCompaniesQuery : EfUseCase, IGetUsersCompanies
    {
        public EfGetUsersCompaniesQuery(Asp2023DbContext context) : base(context)
        {
        }

        public int Id => 14;

        public string Name => "Pogledaj sve zaposlene sa userima";

        public string Description => "";

        public IEnumerable<GetUsersCompaniesDto> Execute(KeywordSearchDto search)
        {
            var query = Context.UserCompanies.Include(x=>x.User).Include(x=>x.Company).AsQueryable();

            if(search.Keyword != null)
            {
                query = query.Where(x => x.User.FirstName.Contains(search.Keyword) ||
                                         x.User.LastName.Contains(search.Keyword) ||
                                        x.User.Email.Contains(search.Keyword) ||
                                         x.Company.NameCompany.Contains(search.Keyword));
            }

            var results = query.Select(x => new GetUsersCompaniesDto
            {
                CompanyName = x.Company.NameCompany,
                UserIdentity = x.User.FirstName + " " + x.User.LastName + " " + x.User.Email
            });

            return results;
        }
    }
}
