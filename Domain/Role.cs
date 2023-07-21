using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Role : Base
    {
        public string NameRole { get; set; }
        public virtual ICollection<User> Users { get; set; } = new List<User>();
        public virtual ICollection<UseCaseRole> UseCaseRoles { get; set; } = new List<UseCaseRole>();
    }
}
