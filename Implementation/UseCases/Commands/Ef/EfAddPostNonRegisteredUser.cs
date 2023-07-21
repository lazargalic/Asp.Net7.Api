using Application.UseCases.Commands;
using Application.UseCases.Dto;
using Application.UseCases.Queries.Searches;
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
    public class EfAddPostNonRegisteredUser : EfUseCase, IAddPostNonRegisteredUser
    {
        private AddPostValidator ValidatorPost { get; }
        private NonRegisteredUserValidator ValidatorNonRegUser { get; }
        public EfAddPostNonRegisteredUser(
            Asp2023DbContext context, 
            AddPostValidator validator1,
            NonRegisteredUserValidator validator2) : base(context)
        {
            ValidatorPost = validator1;
            ValidatorNonRegUser = validator2;
        }

        public int Id => 19;
        public string Name => "Dodavanje artikla neregistrovani korisnici";

        public string Description => "";

        public void Execute(CreateArticleNonRegisteredUserDto data)
        {
            var nonRegisteredUserToAdd =data.NonRegisteredUserToAdd;
            var articleToAddRequest =data.ArticleToAdd;
            //validacija nonRegisteredUserToAdd

             ValidatorPost.ValidateAndThrow(articleToAddRequest);
             ValidatorNonRegUser.ValidateAndThrow(nonRegisteredUserToAdd);

            var addNonRegUser = new Domain.NonRegisteredUser
            {
                FirstName = nonRegisteredUserToAdd.FirstName,
                LastName = nonRegisteredUserToAdd.LastName,
                Email = nonRegisteredUserToAdd.Email,
                PhoneNumber = nonRegisteredUserToAdd.PhoneNumber,
            };

            Context.NonRegisteredUsers.Add(addNonRegUser);
            Context.SaveChanges();

            int lastInsertedNonRegUserId= addNonRegUser.Id;

            var addArticle = new Article
            {
                NameArticle = articleToAddRequest.NameArticle,
                Description = articleToAddRequest.Description,
                AdditionalDescription = articleToAddRequest.AdditionalDescription,
                MainContent = articleToAddRequest.MainContent,
                Quote = articleToAddRequest.Quote,
                Beggin = articleToAddRequest.Beggin,
                End = articleToAddRequest.End,
                MainPicturePath = articleToAddRequest.MainPicturePath != null ? articleToAddRequest.MainPicturePath : "/",
                TownshipId = articleToAddRequest.TownshipId,
                UserId=null,   // 
                NonRegisteredUserId = lastInsertedNonRegUserId,
                CategoryDesignArticleId=articleToAddRequest.CategoryDesignArticleId,
                CategoryDimensionId= articleToAddRequest.CategoryDimensionId
            };


            //Context.Articles.Add(addArticle);
            //Context.SaveChanges();

            //int lastInsertedArticleId = addArticle.Id;

            var moreImages = new List<ArticleImage>();

            if (articleToAddRequest.MoreImages != null && articleToAddRequest.MoreImages.Any())
            {
                foreach(var a in articleToAddRequest.MoreImages)
                {
                    moreImages.Add(new ArticleImage
                    {
                        //ArticleId = lastInsertedArticleId,
                        Article=addArticle,
                        ImagePath = a.ImagePath,
                    });
                }

                addArticle.ArticleImages = moreImages ;


            }

            Context.Articles.Add(addArticle);
            Context.SaveChanges();




        }


    }
}
