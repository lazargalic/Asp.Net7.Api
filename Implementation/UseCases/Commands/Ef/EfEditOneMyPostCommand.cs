using Application;
using Application.Exceptions;
using Application.UseCases.Commands;
using Application.UseCases.Dto;
using DataAccess;
using FluentValidation;
using Implementation.Validators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Ef
{
    public class EfEditOneMyPostCommand : EfUseCase, IEditOneMyPostCommand
    {
        private IApplicationUser User { get; }
        private EditPostValidator Validator { get; }
        public EfEditOneMyPostCommand(Asp2023DbContext context, IApplicationUser user, EditPostValidator validator) : base(context)
        {
            User = user;
            Validator = validator;
        }

        public int Id => 33;

        public string Name => "Izmeni objavu" ;

        public string Description => "";

        public void Execute(EdititingArticle data)
        {
            var toEdit = Context.Articles.Include(x => x.ArticleImages)
                                        .FirstOrDefault(x => x.Id == data.Id);
            if (toEdit == null)
            {
                throw new EntityNotFoundException("Article", data.Id);
            }

            if (toEdit.UserId != User.Id)
            {
                throw new ForbiddenExecutionException(this.Name + " Menjate tudju objavu", User.Email);
            }

            Validator.ValidateAndThrow(data);


            if (!string.IsNullOrEmpty(data.MainPicturePath))
            {
                toEdit.MainPicturePath = data.MainPicturePath;
            }

            toEdit.NameArticle = data.NameArticle;
            toEdit.Description = data.Description;
            toEdit.AdditionalDescription = data.AdditionalDescription;
            toEdit.Quote = data.Quote;
            toEdit.MainContent = data.MainContent;
            toEdit.Beggin = data.Beggin;
            toEdit.End = data.End;
            //categoryDimension ne moze da se menja 
            toEdit.TownshipId = data.TownshipId;

            Context.SaveChanges();



        }


    }
}
