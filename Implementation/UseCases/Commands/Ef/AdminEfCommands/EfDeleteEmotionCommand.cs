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
    public class EfDeleteEmotionCommand : EfUseCase, IDeleteEmotionCommand
    {
        public EfDeleteEmotionCommand(Asp2023DbContext context) : base(context)
        {
        }

        public int Id => 8;

        public string Name => "Deaktiviraj Emociju";

        public string Description => "";

        public void Execute(int data)
        {
            var objToDelete = Context.Emotions.Find(data);

            if(objToDelete == null)
            {
                throw new EntityNotFoundException("Emotions",data);
            }

            objToDelete.IsActive = false;
            Context.SaveChanges();
        }
    }
}
