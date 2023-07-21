using Application;
using Application.Exceptions;
using Application.UseCases.Dto;
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
    public class EfGetReactionToCurrentPost : EfUseCase, IGetReactionToCurrentPost
    {
        private IApplicationUser User { get;set; }
        public EfGetReactionToCurrentPost(Asp2023DbContext context, IApplicationUser user) : base(context)
        {
            User = user;
        }

        public int Id => 31;

        public string Name => "EfGetReactionToCurrentPost";

        public string Description => "";

        public ReactedEmotionIdToPost Execute(int search)
        {

            var articleToFind = Context.Articles.Find(search);
            if(articleToFind == null)
            {
                throw new EntityNotFoundException("Article", search);
            }

           /* var userToFind = Context.Users.Find(User.Id);
            if (userToFind == null)
            {
                throw new EntityNotFoundException("Users", User.Id);
            }*/

            var toReturn = Context.ArticleUserEmotions
                                    .Include(x => x.Emotion)
                                    .Where(y => y.UserId == User.Id && y.ArticleId == search)
                                    .Select(z => new ReactedEmotionIdToPost
                                    {
                                        IdEmotion = z.EmotionId,
                                        NameEmotion = z.Emotion.NameEmotion
                                    }).FirstOrDefault();

            if(toReturn == null)
            {
                return new ReactedEmotionIdToPost
                {
                    IdEmotion = 0,
                    NameEmotion = ""
                };
            }

            return toReturn;

        }
    }
}
