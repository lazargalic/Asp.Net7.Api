using Application.Exceptions;
using Application.UseCases.Commands.AdminCommands;
using Application.UseCases.Dto;
using DataAccess;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Ef.AdminEfCommands
{
    public class EfEditEmotionCommand : EfUseCase, IEditEmotionCommand
    {
        UpdateEmotionValidator _editValidator;
        public EfEditEmotionCommand(Asp2023DbContext context, UpdateEmotionValidator editValidator) : base(context)
        {
            _editValidator = editValidator;
        }

        public int Id =>  30;

        public string Name => "Izmeni emociju";

        public string Description => "";

        public void Execute(EditEmotionDto data)
        {
            var objToFind = Context.Emotions.Find(data.Id);

            if (objToFind == null)
            {
                throw new EntityNotFoundException("Emotion", data.Id);
            }

            var newToValidate = new EditEmotionDto
            {
                NewNameEmotion = data.NewNameEmotion,
                NewImagePath = data.NewImagePath,
                //Price = data.NewPrice  // 
            };

            _editValidator.ValidateAndThrow(newToValidate);

            var ifExistsName = Context.Emotions.Where(x=>x.Id!=data.Id).FirstOrDefault(x => x.NameEmotion == newToValidate.NewNameEmotion);
            if (ifExistsName != null)
            {
                throw new AlreadyExistsException(newToValidate.NewNameEmotion);
            }


            objToFind.NameEmotion = data.NewNameEmotion;
            objToFind.ImagePath = data.NewImagePath;
            //objToFind.Price = data.NewPrice;

            Context.SaveChanges();


        }
    }
}
