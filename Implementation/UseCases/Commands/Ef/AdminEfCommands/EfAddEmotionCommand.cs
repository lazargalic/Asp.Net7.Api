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
    public class EfAddEmotionCommand : EfUseCase, IAddEmotionCommand
    {
        private AddEmotionValidator _validator;
        public EfAddEmotionCommand(Asp2023DbContext context, AddEmotionValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 7;

        public string Name => "Dodaj Emocije";

        public string Description => "";

        public void Execute(CreateEmotionDto data)
        {
            var toValidate = new EmotionDto
            {
                NameEmotion = data.NameEmotion,
                ImagePath = data.ImagePath,
                Price = data.Price
            };

            _validator.ValidateAndThrow(toValidate);

            Context.Emotions.Add(new Domain.Emotion
            {
                NameEmotion = data.NameEmotion,
                ImagePath = data.ImagePath,
                Price = data.Price
            });

            Context.SaveChanges();
        }


    }
}
