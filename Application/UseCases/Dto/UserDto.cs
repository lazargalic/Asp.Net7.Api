using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Dto
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class OneUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        //Posts
    }

    public class UpdateOneUserDto
    {
        public int IdUserToUpdate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } //Skoro nikad nece stizati sa fronta jer ne moze da se desifruje BCrpyt
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
        public string PhoneNumber { get; set; }
        public string IdentityNumber { get; set; }

        //Posts
    }
}
