using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class ForbiddenExecutionException : Exception
    {
        public string User { get; }
        public string UseCase { get;}

        public ForbiddenExecutionException(string useCase, string user) :
            base("Korisnik " + user + " nema privilegiju izvrsavanja pod nazivom " + useCase + ".")
        {
            User = user;
            UseCase = useCase;
        }
    }

    public class TokenNotValidException : Exception
    {
        public TokenNotValidException() :
            base("Izgleda da niste predugo koristili aplikaciju, molimo vas ulogujte se ponovo!")
        {
        }
    }

    public class AccountNotActivated : Exception
    {
        public AccountNotActivated() :
            base("Vaš nalog nije aktiviran. Proverite email za aktivaciju ili kontaktirajte administratore!")
        {
        }
    }

}
