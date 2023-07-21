using Application.Exceptions;
using Application.UseCases.Commands.AdminCommands;
using Application.UseCases.Dto;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Ef.AdminEfCommands
{
    public class EfAddUseCaseToRoleCommand : EfUseCase, IAddUseCaseToRoleCommand
    {
        public EfAddUseCaseToRoleCommand(Asp2023DbContext context) : base(context)
        {
        }

        public int Id => 4;

        public string Name => "Pridruzi Use Case ulozi";

        public string Description => "";

        public void Execute(AddUseCasesToRoleDto data)
        {
            
            try
            {
                var roleToFind = Context.Roles.Find(data.RoleId);

                if (roleToFind == null)
                {
                    throw new EntityNotFoundException("Roles", data.RoleId);
                }

                var ifAlreadyExists = Context.UseCaseRoles
                        .Where(x => x.RoleId == data.RoleId && x.UseCaseId == data.UseCaseId).FirstOrDefault();

                if (ifAlreadyExists != null)
                {
                    throw new AlreadyExistsException(this.Name);
                }

                var useCaseRoleToAdd = new Domain.UseCaseRole
                {
                    RoleId = data.RoleId,
                    UseCaseId = data.UseCaseId
                };
                Context.UseCaseRoles.Add(useCaseRoleToAdd);


                int idRole = roleToFind.Id;

                var allUsersIdsWithThisRole = Context.Users.Where(x => x.RoleId == idRole).Select(x => x.Id).ToList();
                //U ovom delu koda azuriram svim Userima Nove Use Case-ove za tu novu rolu u skroz drugoj tabeli AllUserUseCase koja nema dodirnih veza sa ovom tabelom UseCaseRoles. 
                //Ovo sam malo iskomplikovao da bi bio zahtevniji upit i ako je pomalo redundantno.
                //Zeleo sam da na jednom mestu imam sve user use case-ove zbog lakse preglednosti i zbog dohvatanja tih Use-Case-ova na jednom mestu preko refleksije koju nisam stigao da probam da uradim . 


                foreach (var userId in allUsersIdsWithThisRole)
                {
                    Context.AllUserUseCases.Add(new Domain.AllUserUseCase
                    {
                        UseCaseId = data.UseCaseId,
                        UserId = userId
                    });
                }
                Context.SaveChanges();
            }
            catch(Exception e)
            {
                throw new ConflictInExecution("user", this.Name);
            }


        }
    }
}
