using Application;
using Application.UseCases.PaginationDto;
using Application.UseCases.Queries;
using Application.UseCases.Queries.Searches;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Implementation.UseCases.Queries.Ef
{
    public class EfGetArticlesQuery : EfUseCase, IGetArticlesQuery
    {
        IApplicationUser User { get; set; }
        public EfGetArticlesQuery(Asp2023DbContext context, IApplicationUser user) : base(context)
        {
            User = user;
        }

        public int Id => 22;

        public string Name => "Dohvati artikle";

        public string Description => "";

        public PagedResponse<GetArticlesCommentDto> Execute(SearchArticlesDto search)
        {

            var query = Context.Articles
                            //.Include(x => x.CommentArticles)
                           // .ThenInclude(y => y.ChildComments)
                             // .ThenInclude(u => u.Sticker)
                             .Include(x => x.ArticleUserEmotions)
                                .ThenInclude(x => x.Emotion)
                             .Include(x => x.User)
                             .Include(x => x.Township)
                                .ThenInclude(x => x.Country)
                             .AsQueryable();

            if (User.RoleId != 2)
            {
                query = query.Where(x => x.DeletedAt == null);
            }



            if(!string.IsNullOrEmpty(search.NameArticle))
            {
                query = query.Where(x => x.NameArticle.Contains(search.NameArticle));
            }

            if (!string.IsNullOrEmpty(search.DescriptionKeyword))
            {
                query = query.Where(x => x.Description.Contains(search.DescriptionKeyword));
            }
            
            if (search.CountryId != null && search.CountryId != 0)
            {
                query = query.Where(x => x.Township.CountryId == search.CountryId);
            }
            if (search.Townships != null && search.Townships.Count() != 0)
            {
                query = query.Where(x => search.Townships.Contains(x.TownshipId) );
            }

            if ( search.CategoryDimensionId !=null && search.CategoryDimensionId !=0)
            {
                query = query.Where(x => x.CategoryDimensionId== search.CategoryDimensionId);
            }


            if (search.End != null && search.End != default(DateTime) )
            {
                query = query.Where(x => x.End  < search.End );
            }
            if (search.Beggin != null && search.Beggin != default(DateTime))
            {
                query = query.Where(x => x.Beggin > search.Beggin);
            }


            if (search.PerPage == null || search.PerPage < 1)
            {
                search.PerPage = 12;
            }

            if (search.Page == null || search.Page < 1)
            {
                search.Page = 1;
            }

            var toSkip = (search.Page.GetValueOrDefault() - 1) * search.PerPage.Value;
            var response = new PagedResponse<GetArticlesCommentDto>();
            response.TotalCount = query.Count();
            response.Data = query.Skip(toSkip).Take(search.PerPage.Value).Select(x => new GetArticlesCommentDto
            {
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
                            Id=0,
                            FistName=x.NonRegisteredUser.FirstName,
                            LastName=x.NonRegisteredUser.LastName,
                            Email=x.NonRegisteredUser.Email
                        }
                        : new AuthorDto
                        {
                            Id = x.User.Id,
                            FistName = x.User.FirstName,
                            LastName = x.User.LastName,
                            Email = x.User.Email
                        },
                EmotionsNumber=x.ArticleUserEmotions.Where(y=>y.ArticleId==x.Id).Count(),
                /*Emotions =  new EmotionDto2 
                {
                    Love = x.ArticleUserEmotions.Where(y=>y.EmotionId==2 && y.ArticleId==x.Id).Select(z=>z.User.FirstName + " " + z.User.LastName),
                    Fire = x.ArticleUserEmotions.Where(y=>y.EmotionId==1 && y.ArticleId == x.Id).Select(z => z.User.FirstName + " " + z.User.LastName),
                    Dislike = x.ArticleUserEmotions.Where(y=>y.EmotionId==3 && y.ArticleId == x.Id).Select(z => z.User.FirstName + " " + z.User.LastName),
                },
                Comments = x.CommentArticles.Where(x=>x.ParrentCommentId==null && x.DeletedAt == null)
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
                }),*/
                TotalPrice = x.TotalPrice,
                CreatedAt = x.CreatedAt,
                DeletedAt = x.DeletedAt,
                LastUpdatedAt = x.LastUpdatedAt 

            }).ToList();

            response.CurrentPage = search.Page.GetValueOrDefault();
            response.ItemsPerPage = search.PerPage.GetValueOrDefault();

            return response;


        }
    }
}
