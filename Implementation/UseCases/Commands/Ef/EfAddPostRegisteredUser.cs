using Application;
using Application.Exceptions;
using Application.UseCases.Commands;
using Application.UseCases.Dto;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Ef
{
    public class EfAddPostRegisteredUser : EfUseCase, IAddPostRegisteredUser
    {

        private IApplicationUser ulogovaniUser_;
        private AddPostValidator ValidatorPost { get; }

        public EfAddPostRegisteredUser(
                    Asp2023DbContext context,
                    IApplicationUser ulogovaniUser,
                    AddPostValidator validator1) : base(context)
        {
            ulogovaniUser_= ulogovaniUser;
            ValidatorPost = validator1;
        }

        public int Id => 20;

        public string Name => "Dodaj Post Registrovan korisnik";

        public string Description =>  "";

        public void Execute(CreateArticleRegisteredUserDto data)
        {

            var objUser = Context.Users.Find(ulogovaniUser_.Id);
            if (objUser == null)
            {
                throw new EntityNotFoundException("Users", ulogovaniUser_.Id);
            }

            var articleToAddRequest = data.ArticleToAdd;

            ValidatorPost.ValidateAndThrow(articleToAddRequest);

            var addArticle = new Article
            {
                NameArticle = articleToAddRequest.NameArticle,
                Description = articleToAddRequest.Description,
                AdditionalDescription = articleToAddRequest.AdditionalDescription,
                MainContent = articleToAddRequest.MainContent,
                Quote = articleToAddRequest.Quote,
                Beggin = articleToAddRequest.Beggin,
                End = articleToAddRequest.End,
                MainPicturePath = articleToAddRequest.MainPicturePath != null? articleToAddRequest.MainPicturePath: "/" ,
                TownshipId = articleToAddRequest.TownshipId,
                UserId = objUser.Id,   //  ! 
                NonRegisteredUserId = null,
                CategoryDesignArticleId = articleToAddRequest.CategoryDesignArticleId,
                CategoryDimensionId = articleToAddRequest.CategoryDimensionId
            };

            //Context.Articles.Add(addArticle);
            //Context.SaveChanges();

            //int lastInsertedArticleId = addArticle.Id;

            var moreImages = new List<ArticleImage>();

            if (articleToAddRequest.MoreImages!=null && articleToAddRequest.MoreImages.Any() )
            {
                foreach (var a in articleToAddRequest.MoreImages)
                {
                    Context.ArticleImages.Add(new ArticleImage
                    {
                        //ArticleId = lastInsertedArticleId,
                        Article=addArticle,
                        ImagePath = a.ImagePath,
                    });
                }

                addArticle.ArticleImages = moreImages;

            }


            Context.Articles.Add(addArticle);
            Context.SaveChanges();



        }
    }
}
