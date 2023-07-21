using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Dto
{
    public class UserCompanyDto
    {
        public int UserId { get; set; }
        public int CompanyId { get; set; }
    }

    public class GetUsersCompaniesDto
    {
        public string UserIdentity { get; set; }
        public string CompanyName { get; set; }
    }
}
