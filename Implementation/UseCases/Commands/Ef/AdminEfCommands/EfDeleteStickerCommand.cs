using Application.Exceptions;
using Application.UseCases.Commands.AdminCommands;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Ef.AdminEfCommands
{
    public class EfDeleteStickerCommand : EfUseCase, IDeleteStickerCommand
    {
        public EfDeleteStickerCommand(Asp2023DbContext context) : base(context)
        {
        }

        public int Id => 17;

        public string Name => "Obrisi Stiker";

        public string Description => "" ;

        public void Execute(int data)
        {
            var objToDelete = Context.Stickers.Find(data);

            if (objToDelete == null)
            {
                throw new DeleteButNotExistsErrorException();
            }

            objToDelete.IsActive = false;
            Context.SaveChanges();
        }
    }
}
