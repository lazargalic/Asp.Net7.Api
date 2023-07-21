using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class AlreadyReactedException : Exception
    {
        public AlreadyReactedException() : base("Vec ste reagovali na ovu objavu. Ponistite reakciju pa reagujte ponovo.")
        {
        }
    }
}
