using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class DeleteButNotExistsErrorException : Exception
    {
        public DeleteButNotExistsErrorException() 
            : base("Zapis koji pokusavate da obrisete ne postoji u bazi podataka.")
        {

        }
    }
}
