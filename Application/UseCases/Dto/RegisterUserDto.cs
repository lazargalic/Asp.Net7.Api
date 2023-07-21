using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Dto
{
    public class RegisterUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? IdentityNumber { get; set; }
        public string? PhoneNumber { get; set; }
    }

    public class AdminSelectRegisteredUsersDto
    {
        public int Id { get; set; }
        public SelectRoleAdmin? Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string? IdentityNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public IEnumerable<UseCasesDto> UserUseCases { get; set; } = new List<UseCasesDto>();
    }

    public class SelectRoleAdmin
    {
        public int RoleId { get; set; }
        public string NameRole { get; set; }
    }

}
