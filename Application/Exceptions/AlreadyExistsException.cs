using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException(string useCase)
            : base("Doslo je do greske u bazi podataka prilikom izvrsavanja: " + useCase + ". Ovaj zapis vec postoji u bazi podataka.")
        {

        }
    }
}
