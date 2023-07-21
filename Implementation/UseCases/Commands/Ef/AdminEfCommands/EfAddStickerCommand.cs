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
    public class EfAddStickerCommand : EfUseCase, IAddStickerCommand
    {
        private AddStickerValidation Validator { get; }
        public EfAddStickerCommand(Asp2023DbContext context, AddStickerValidation validator) : base(context)
        {
            Validator = validator;
        }

        public int Id => 15;

        public string Name => "Dodaj Stiker u program";

        public string Description => "";

        public void Execute(CreateStickersDto data)
        {
            Validator.ValidateAndThrow(data);

            Context.Stickers.Add(new Domain.Sticker
            {
                NameSticker = data.NameSticker,
                StickerPath = data.PathSticker,
            });

            Context.SaveChanges();
        }
    }
}
