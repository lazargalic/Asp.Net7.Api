using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Country : Base
    {
        public string NameCountry { get; set; }
        public virtual ICollection<Township> Townships { get; set; } = new List<Township>();
    }
}
