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
    public class EfEditStickerCommand : EfUseCase, IEditStickerCommand
    {
        private UpdateStickerValidator Validator { get; }
        public EfEditStickerCommand(Asp2023DbContext context, UpdateStickerValidator validator) : base(context)
        {
            Validator = validator;
        }

        public int Id => 18;

        public string Name => "Izmeni Stiker";

        public string Description => "";

        public void Execute(EditStickerDto data)
        {
            var objToFind = Context.Stickers.Find(data.Id);

            if (objToFind == null)
            {
                throw new EntityNotFoundException("Sticker", data.Id);
            }

            var newToValidate = new EditStickerDto //promenio sam u onu pocetnu klasu za validaciju gde sam kreirao
            {
                NewNameSticker = data.NewNameSticker,
                NewPathSticker = data.NewPathSticker,
            };

            Validator.ValidateAndThrow(newToValidate);

            var ifExistsName = Context.Stickers.Where(x => x.Id != data.Id).FirstOrDefault(x => x.NameSticker == newToValidate.NewNameSticker);
            if (ifExistsName != null)
            {
                throw new AlreadyExistsException(newToValidate.NewNameSticker);
            }




            objToFind.NameSticker = data.NewNameSticker;
            objToFind.StickerPath = data.NewPathSticker;

            Context.SaveChanges();
        }
    }
}
