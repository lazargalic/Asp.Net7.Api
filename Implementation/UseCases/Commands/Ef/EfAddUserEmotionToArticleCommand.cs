using Application;
using Application.Exceptions;
using Application.UseCases.Commands;
using Application.UseCases.Dto;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Ef
{
    public class EfAddUserEmotionToArticleCommand : EfUseCase, IAddUserEmotionToArticleCommand
    {
        private IApplicationUser _user;
        public EfAddUserEmotionToArticleCommand(Asp2023DbContext context, IApplicationUser user) : base(context)
        {
            _user = user;
        }

        public int Id => 23;

        public string Name => "Reaguj na objavu";

        public string Description => "";

        public void Execute(AddUserEmotionToArticleDto data)
        {
            var objUser = Context.Users.Find(_user.Id);
            if (objUser == null)
            {
                throw new EntityNotFoundException("User", _user.Id);
            }

            var objArt= Context.Articles.Find(data.ArticleId);
            if (objArt == null)
            {
                throw new EntityNotFoundException("Articles", data.ArticleId);
            }

            var objEm = Context.Emotions.Find(data.EmotionId);
            if (objEm == null)
            {
                throw new EntityNotFoundException("Emotions", data.EmotionId);
            }

            var ifExists = Context.ArticleUserEmotions
                .Where(x => x.ArticleId == data.ArticleId && x.UserId == _user.Id)
                .FirstOrDefault();

            if (ifExists != null)
            {
                if(ifExists.EmotionId==data.EmotionId)
                {
                    throw new AlreadyReactedException();
                }
                else
                {
                    ifExists.EmotionId = data.EmotionId;
                }
            }
            else
            {
                Context.ArticleUserEmotions.Add(new Domain.ArticleUserEmotion
                {
                    ArticleId = data.ArticleId,
                    EmotionId = data.EmotionId,
                    UserId = _user.Id
                });
            }

            Context.SaveChanges();
        }
    }
}
