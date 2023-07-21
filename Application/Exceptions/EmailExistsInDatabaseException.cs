using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class EmailExistsInDatabaseException : Exception
    {
        public EmailExistsInDatabaseException()
            : base("Doslo je do greske prilikon dodavanja u bazi podataka. Ovaj Email-a vec postoji u bazi podataka.")
        {

        }
    }

}
