using Application.UseCases.Dto;
using DataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class AddPostValidator : AbstractValidator<CreatingArticle>
    {
        public AddPostValidator(Asp2023DbContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
             
            RuleFor(x => x.NameArticle).NotEmpty().WithMessage("Ime je obavezno polje.")
                                  .NotNull().WithMessage("Ime ne sme biti null.")
                                  .MinimumLength(2).WithMessage("Ime ne sme biti krace od 2 karaktera.")
                                  .MaximumLength(80).WithMessage("Ime ne sme biti duze od 80 karaktera.");

            RuleFor(x => x.MainPicturePath).NotEmpty().WithMessage("Glavna slika je obavezna .")
                                   .NotNull().WithMessage("Glavna slika ne sme biti null.")
                                   .MinimumLength(2).WithMessage("Glavna slika ne sme biti kraca od 2 karaktera.")
                                   .MaximumLength(220).WithMessage("Glavna slika ne sme biti duze od 220 karaktera.");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Opis je obavezan .")
                       .NotNull().WithMessage("Opis ne sme biti null.")
                       .MinimumLength(1).WithMessage("Opis ne sme biti kraci od 1 karaktera.")
                       .MaximumLength(745).WithMessage("Opis ne sme biti duzi od 745 karaktera.");

            RuleFor(x => x.AdditionalDescription)  
                    .MaximumLength(445).WithMessage("Opis ne sme biti duzi od 745 karaktera.");

            RuleFor(x => x.MainContent)
                .MaximumLength(3000).WithMessage("Glavni opis ne sme biti duzi od 3000 karaktera.");


            //MainContent Maximum

            RuleFor(x => x.Quote)
                .MaximumLength(385).WithMessage("Opis ne sme biti duzi od 745 karaktera.");

            RuleFor(x => x.Beggin).Must(BeValidDateTime)
                    .WithMessage("Format datuma nije validan.");

            RuleFor(x => x.End).Must(BeValidDateTime)
                .WithMessage("Format datuma nije validan.");

            RuleFor(x => x.CategoryDimensionId)
                .Must(cat => context.CategoryDimensions.Any(y=>y.Id==cat))
                .WithMessage("Ne postoji kategorija dimenzija u bazi.");

            RuleFor(x => x.CategoryDesignArticleId)
                    .Must(cat => context.CategoryDesignArticles.Any(y => y.Id == cat))
                    .WithMessage("Ne postoji kategorija dizajna u bazi.");

            RuleFor(x => x.TownshipId)
                    .Must(tow => context.Townships.Any(y => y.Id == tow))
                    .WithMessage("Ne postoji odabrana opstina u bazi.");

        }

        private bool BeValidDateTime(DateTime dateTime)
        {
            return true;
        }
    }
}
