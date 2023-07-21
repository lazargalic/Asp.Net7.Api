using Application.UseCases.Queries;
using Application.UseCases.Queries.Searches;
using AutoMapper;
using DataAccess;
using Implementation.AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.Ef
{
    public class EfIGetOneArticleQuery : EfUseCase, IGetOneArticleQuery
    {

        protected IMapper MyMapper { get; }

        public EfIGetOneArticleQuery(Asp2023DbContext context) : base(context)
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

             MyMapper = config.CreateMapper();
        }

        public int Id => 26;

        public string Name => "Jedan Artikal";

        public string Description => "";

        public GetArticlesCommentDto Execute(int search)
        {
            var objToFind = Context.Articles.Find(search);
            if(objToFind== null)
            {
                return new GetArticlesCommentDto { };
            }



            var toReturn = Context.Articles.Where(x => x.Id == search)
                .Select(x => new GetArticlesCommentDto  {
                    Id = x.Id,
                    NameArticle = x.NameArticle,
                    MainPicturePath = x.MainPicturePath,
                    Description = x.Description,
                     AdditionalDescription = x.AdditionalDescription,
                     Quote = x.Quote,
                     MainContent = x.MainContent,
                    Beggin = x.Beggin,
                    End = x.End,
                    CategoryDimensionId=x.CategoryDimensionId,
                    Township = new TownshipDto
                    {
                        Id = x.Township.Id,
                        NameTownship = x.Township.NameTownship,
                        NameCountry = x.Township.Country.NameCountry,
                        IdCountry = x.Township.Country.Id
                    },
                    Author = x.User == null ? new AuthorDto
                    {
                        Id = 0,
                        FistName = x.NonRegisteredUser.FirstName,
                        LastName = x.NonRegisteredUser.LastName,
                        Email = x.NonRegisteredUser.Email
                    }
                        : new AuthorDto
                        {
                            Id = x.User.Id,
                            FistName = x.User.FirstName,
                            LastName = x.User.LastName,
                            Email = x.User.Email
                        },
                    EmotionsNumber =x.ArticleUserEmotions.Where(y=>y.ArticleId==x.Id).Count(),
                    Emotions =  new EmotionDto2 
                    {
                        Love = x.ArticleUserEmotions.Where(y=>y.EmotionId==2 && y.ArticleId==x.Id).Select(z=>z.User.FirstName + " " + z.User.LastName),
                        Fire = x.ArticleUserEmotions.Where(y=>y.EmotionId==1 && y.ArticleId == x.Id).Select(z => z.User.FirstName + " " + z.User.LastName),
                        Dislike = x.ArticleUserEmotions.Where(y=>y.EmotionId==3 && y.ArticleId == x.Id).Select(z => z.User.FirstName + " " + z.User.LastName),
                    },
                    Comments = x.CommentArticles.Where(x => x.ParrentCommentId == null && x.DeletedAt == null)
                                            .Select(y => new CommenttDto
                    {
                        IdComment = y.Id,
                        Content = y.Content == null ? "" : y.Content,
                        StickerId = y.StickerId,
                        User = y.User.FirstName + " " + y.User.LastName,
                        UserId = y.UserId,
                        Date = y.CreatedAt,
                        ChildCommentts = y.ChildComments.Where(x => x.DeletedAt == null)
                                                        .Select(z => new CommenttDto
                        {
                            IdComment = z.Id,
                            Content = z.Content == null ? "" : z.Content,
                            StickerId = z.StickerId,
                            User = z.User.FirstName + " " + z.User.LastName,
                            UserId = z.UserId,
                            Date = y.CreatedAt,
                        })
                    }),
                    CreatedAt = x.CreatedAt,
                    DeletedAt = x.DeletedAt,
                    LastUpdatedAt = x.LastUpdatedAt
                }).FirstOrDefault();

            return toReturn;

            //var mapped = MyMapper.Map<GetArticlesCommentDto>(objToMap);

            //return mapped;

        }
    }
}
