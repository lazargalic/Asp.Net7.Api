using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Dto
{
    public class UseCasesDto
    {
        public int UseCaseId { get; set; }
    }
    public class CreateUserUseCasesDto
    {
        public int UserId { get; set; }
        public int UseCaseId { get; set; }
    }

    public class DeleteUserUseCasesDto
    {
        public int UserId { get; set; }
        public int UseCaseId { get; set; }
    }

    public class AddUseCasesToRoleDto
    {
        public int RoleId { get; set; }
        public int UseCaseId { get; set; }
    }
    public class DeleteUseCasesToRoleDto
    {
        public int RoleId { get; set; }
        public int UseCaseId { get; set; }
    }
}
