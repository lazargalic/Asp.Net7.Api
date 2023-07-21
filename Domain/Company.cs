using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Company : Entity
    {
        public int Id { get; set; }
        public string NameCompany { get; set; }
        public int? Discount { get; set; }
        //public int IdTownship { get; set; } ne treba

        public virtual ICollection<UserCompany> UserCompany { get; set; } = new List<UserCompany>();
    }
}
