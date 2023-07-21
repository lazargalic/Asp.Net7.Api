using Application.Exceptions;
using Application.UseCases;
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
    public class EfAdminGetAllRegisteredUsersQuery : EfUseCase, IAdminGetAllRegisteredUsers
    {
        public EfAdminGetAllRegisteredUsersQuery(Asp2023DbContext context) : base(context)
        {

        }

        public int Id => 2;

        public string Name => "Admin Dohvata Registrovane Usere";

        public string Description => "";

        public IEnumerable<AdminSelectRegisteredUsersDto> Execute(SearchRegisteredUsersDto search)
        {
            try
            {
                var query = Context.Users.Include(x => x.AllUserUseCases).AsQueryable();

                if (!string.IsNullOrEmpty(search.Keyword))
                {
                    query = query.Where(x => x.FirstName.Contains(search.Keyword) ||
                                           x.LastName.Contains(search.Keyword) ||
                                           x.Email.Contains(search.Keyword) ||
                                           x.IdentityNumber != null && x.IdentityNumber.Contains(search.Keyword) ||
                                           x.PhoneNumber != null && x.PhoneNumber.Contains(search.Keyword)
                    );
                }


                if (search.IsActive != null)
                {
                    query = query.Where(x => x.IsActive == search.IsActive);
                }

                if (search.UseCaseId != null)
                {
                    query = query.Where(x => x.AllUserUseCases.Any(y => y.UseCaseId == search.UseCaseId));
                }


                var result = query.Select(x => new AdminSelectRegisteredUsersDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    IsActive = x.IsActive,
                    CreatedAt = x.CreatedAt,
                    IdentityNumber = x.IdentityNumber,
                    PhoneNumber = x.PhoneNumber,
                    Role = new SelectRoleAdmin
                    {
                        NameRole= x.Role.NameRole,
                        RoleId= x.RoleId
                    },
                    DeletedAt =  x.DeletedAt != null ? x.DeletedAt : null ,
                    LastUpdatedAt =  x.LastUpdatedAt != null ? x.LastUpdatedAt : null ,
                    UserUseCases = x.AllUserUseCases.Select(y => new UseCasesDto
                    {
                        UseCaseId = y.UseCaseId
                    })
                }).ToList();

                return result;
            }
            catch (Exception e)
            {
                throw new ConflictInExecution("user", "");
            }


        }
    }
}
