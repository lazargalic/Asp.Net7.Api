using Application;
using Application.Exceptions;
using Application.UseCases.Dto;
using Application.UseCases.PaginationDto;
using Application.UseCases.Queries;
using Application.UseCases.Queries.Searches;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.Ef
{
    public class EfGetPostsFromOneRegUserQuery : EfUseCase, IGetPostsFromOneRegUserQuery
    {
        public IApplicationUser User { get; }
        public EfGetPostsFromOneRegUserQuery(Asp2023DbContext context, IApplicationUser user) : base(context)
        {
            User = user;
        }

        public int Id => 32;

        public string Name => "Artikli jednog Usera";

        public string Description => "";

        public PagedResponse<GetArticlesCommentDto> Execute(SearchKeywordDto search)
        {
            var user = Context.Users.Find(User.Id);
            if (user == null) throw new EntityNotFoundException("User", user.Id);

            var query = Context.Articles
                 .Include(x => x.ArticleUserEmotions)
                    .ThenInclude(x => x.Emotion)
                 .Include(x => x.User)
                 .Include(x => x.Township)
                    .ThenInclude(x => x.Country)
                 .Where(x=>x.UserId == User.Id && x.DeletedAt == null);  //iz tokena samo svoje vidi


            if (!string.IsNullOrEmpty(search.NameArticle))
            {
                query = query.Where(x => x.NameArticle.Contains(search.NameArticle));
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
                CategoryDimensionId = x.CategoryDimensionId,
                Township = new TownshipDto
                {
                    Id = x.Township.Id,
                    NameTownship = x.Township.NameTownship,
                    NameCountry = x.Township.Country.NameCountry,
                    IdCountry = x.Township.Country.Id
                },
                Author = new AuthorDto
                {
                    Id = x.User.Id,
                    FistName = x.User.FirstName,
                    LastName = x.User.LastName,
                    Email = x.User.Email
                },
                EmotionsNumber = x.ArticleUserEmotions.Where(y => y.ArticleId == x.Id).Count(),
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
