using Application;
using Application.Exceptions;
using Application.UseCases.Commands;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Ef
{
    public class EfValidateAccountCommand : EfUseCase, IValidateAccountCommand
    {
        private IApplicationUser User { get; }
        public EfValidateAccountCommand(Asp2023DbContext context, IApplicationUser user) : base(context)
        {
            User = user;
        }

        public int Id => 34;

        public string Name => "Validate Email";

        public string Description => "Validacija Emaila";

        public void Execute(string data)
        {
            var user = Context.Users.FirstOrDefault(x => x.VerificationCode == data);
            if (user == null) {
                throw new ForbiddenExecutionException(this.Name, User.Identity);
            }

            if (!user.IsActive)
            {
                user.IsActive = true;
            }
            
            Context.SaveChanges();

        }
    }
}
