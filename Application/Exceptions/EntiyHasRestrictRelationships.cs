using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class EntiyHasRestrictRelationships : Exception
    {
        public EntiyHasRestrictRelationships()
            : base("Ne mozete obrisati odredjeni Entitet jer sadrzi redove u drugim tabelama koji ne smeju biti obrisani. " )
        {

        }
    }
}
