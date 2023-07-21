using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class EmptyCommentException : Exception
    {
        public EmptyCommentException() : base("Ne mozete komentarisati sa praznim kontentom. Napisite ili Kontent ili Stiker.") { }
    }
}
