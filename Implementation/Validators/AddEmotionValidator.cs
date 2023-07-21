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
    public class AddEmotionValidator : AbstractValidator<EmotionDto>
    {
        public AddEmotionValidator(Asp2023DbContext context) 
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.NameEmotion).NotEmpty().WithMessage("Ime je obavezno polje.")
                                   .NotNull().WithMessage("Ime ne sme biti null.")
                                   .MinimumLength(2).WithMessage("Ime ne sme biti krace od 2 karaktera.")
                                   .MaximumLength(80).WithMessage("Ime ne sme biti duze od 80 karaktera.")
                                   .Must(name => !context.Emotions.Any(x => x.NameEmotion == name))
                                   .WithMessage("Ovo ime vec postoji u bazi podataka.");

            RuleFor(x => x.ImagePath).NotEmpty().WithMessage("Putanja je obavezno polje.")
                       .NotNull().WithMessage("Putanja ne sme biti null.")
                       .MinimumLength(2).WithMessage("Putanja ne sme biti krace od 2 karaktera.")
                       .MaximumLength(120).WithMessage("Putanja ne sme biti duze od 120 karaktera.");

            RuleFor(x => x.Price).NotEmpty().WithMessage("Cena je obavezno polje.")
                                .NotNull().WithMessage("Cena ne sme biti null.")
                                .GreaterThan(0).WithMessage("Cena mora biti veca od 0.");

        }
    }
}
