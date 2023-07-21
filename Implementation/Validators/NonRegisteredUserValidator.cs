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

    public class NonRegisteredUserValidator : AbstractValidator<NonRegisteredUser>
    {
        public NonRegisteredUserValidator(Asp2023DbContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            string regexPatternName = @"\b[A-Z][a-zA-Z]*\b";

            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Ime je obavezno polje.")
                       .NotNull().WithMessage("Ime ne sme biti null.")
                       .MinimumLength(2).WithMessage("Ime ne sme biti krace od 2 karaktera.")
                       .MaximumLength(80).WithMessage("Ime ne sme biti duze od 80 karaktera.")
                       .Matches(regexPatternName).WithMessage("Reci u imenu moraju poceti velikim pocetnim slovom i biti u skladu sa gramatickim formatom.");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Prezime je obavezno polje.")
                                   .NotNull().WithMessage("Prezime ne sme biti null.")
                                   .MinimumLength(2).WithMessage("Prezime ne sme biti krace od 2 karaktera.")
                                   .MaximumLength(80).WithMessage("Prezime ne sme biti duze od 80 karaktera.")
                                   .Matches(regexPatternName).WithMessage("Reci u prezimenu moraju poceti velikim pocetnim slovom i biti u skladu sa gramatickim formatom.");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email je obavezno polje.")
                       .NotNull().WithMessage("Email ne sme biti null.")
                       .MinimumLength(5).WithMessage("Email ne sme biti kraci od 5 karaktera.")
                       .MaximumLength(80).WithMessage("Email ne sme biti duzi od 80 karaktera.")
                       .EmailAddress().WithMessage("Email nije u dobrom formatu.")
                       .Must(email => !context.Users.Any(x => x.Email == email)).WithMessage("Ovaj email vec postoji u bazi podataka. Odaberite novi ili se obratite administratorima.");
            
            RuleFor(x => x.PhoneNumber).MaximumLength(15).WithMessage("Previse karaktera za broj telefona.");


        }
    }
}
