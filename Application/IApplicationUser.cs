using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IApplicationUser
    {
        public string Identity { get; }
        public int Id { get; }
        public int RoleId { get; }
        public IEnumerable<int> UseCaseIds { get; }
        public string Email { get; }
    }
}
