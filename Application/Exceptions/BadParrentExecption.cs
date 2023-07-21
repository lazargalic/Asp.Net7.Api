using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class BadParrentExecption : Exception
    {
        public BadParrentExecption() :base("Komentar ne mozete dodati na komentaru od komentara, koji ima roditeljski komentar.") { }
    }
}
