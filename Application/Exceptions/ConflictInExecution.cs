using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class ConflictInExecution : Exception
    {
        public ConflictInExecution(string user, string useCase)
            : base("Doslo je do konflikta u bazi podataka prilikom izvrsavanja: " + useCase + ", Obratite se administratoru.")
        {

        }
    }
}
