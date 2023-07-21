using Application.UseCases.Queries.Searches;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.AutoMapper
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Article, GetArticlesCommentDto>()
                .ForMember(dest => dest.NameArticle, opt => opt.MapFrom(src => src.NameArticle))
                .ForMember(dest => dest.MainPicturePath, opt => opt.MapFrom(src => src.MainPicturePath))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                 .ForMember(dest => dest.AdditionalDescription, opt => opt.MapFrom(src => src.AdditionalDescription))
                .ForMember(dest => dest.Quote, opt => opt.MapFrom(src => src.Quote))
                 .ForMember(dest => dest.MainContent, opt => opt.MapFrom(src => src.MainContent))
                .ForMember(dest => dest.Beggin, opt => opt.MapFrom(src => src.Beggin))
                .ForMember(dest => dest.End, opt => opt.MapFrom(src => src.End))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src =>
                    new AuthorDto
                    {
                        Id = src.User.Id,
                        Email = src.User.Email,
                        FistName = src.User.FirstName,
                        LastName = src.User.LastName
                    }))
                .ForMember(dest => dest.EmotionsNumber, opt => opt.MapFrom(src => src.ArticleUserEmotions
                        .Where(y => y.ArticleId == src.Id).Count()))
                //                EmotionsNumber=x.ArticleUserEmotions.Where(y=>y.ArticleId==x.Id).Count(),
                .ForMember(dest => dest.Township, opt => opt.MapFrom(src =>
                    new TownshipDto
                    {
                        Id = src.TownshipId,
                        NameTownship = src.Township.NameTownship,
                        NameCountry = src.Township.Country.NameCountry
                    }))
                .ForMember(dest => dest.Emotions, opt => opt.MapFrom(src =>
                    new EmotionDto2
                    {
                        Love = src.ArticleUserEmotions.Where(y => y.EmotionId == 2 && y.ArticleId == src.Id).Select(z => z.User.FirstName + " " + z.User.LastName),
                        Fire = src.ArticleUserEmotions.Where(y => y.EmotionId == 1 && y.ArticleId == src.Id).Select(z => z.User.FirstName + " " + z.User.LastName),
                        Dislike = src.ArticleUserEmotions.Where(y => y.EmotionId == 3 && y.ArticleId == src.Id ).Select(z => z.User.FirstName + " " + z.User.LastName)
                    }))
                    .ForMember(dest => dest.Comments, opt => opt.MapFrom(src =>
                        src.CommentArticles.Select(x => new CommenttDto
                        {
                            IdComment = x.Id,
                            Content = x.Content == null ? "" : x.Content,
                            StickerId = x.StickerId,
                            User = x.User.FirstName + " " + x.User.LastName,
                            ChildCommentts = x.ChildComments.Select(y => new CommenttDto
                            {
                                IdComment = y.Id,
                                Content = y.Content == null ? "" : y.Content,
                                StickerId = y.StickerId,
                                User = y.User.FirstName + " " + y.User.LastName
                            }) 
                        })
                 ));
                    




        }

    }
}
