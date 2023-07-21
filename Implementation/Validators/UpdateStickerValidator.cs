using Application.UseCases.Dto;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class UpdateStickerValidator : AbstractValidator<EditStickerDto>
    {
        public UpdateStickerValidator(Asp2023DbContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.NewNameSticker).NotEmpty().WithMessage("Ime je obavezno polje.")
                                   .NotNull().WithMessage("Ime ne sme biti null.")
                                   .MinimumLength(2).WithMessage("Ime ne sme biti krace od 2 karaktera.")
                                   .MaximumLength(80).WithMessage("Ime ne sme biti duze od 80 karaktera.");
                                   

            RuleFor(x => x.NewPathSticker).NotEmpty().WithMessage("Putanja je obavezno polje.")
                       .NotNull().WithMessage("Putanja ne sme biti null.")
                       .MinimumLength(2).WithMessage("Putanja ne sme biti krace od 2 karaktera.")
                       .MaximumLength(120).WithMessage("Putanja ne sme biti duze od 120 karaktera.");


        }
    }
}
