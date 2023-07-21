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
    public class EfDeleteEmotionArticleUser : EfUseCase, IDeleteEmotionArticleUser
    {
        private IApplicationUser _user;
        public EfDeleteEmotionArticleUser(Asp2023DbContext context, IApplicationUser user) : base(context)
        {
            _user = user;
        }

        public int Id => 24;

        public string Name => "Ukloni reakciju";

        public string Description => "";

        public void Execute(DeleteUserEmotionToArticleDto data)
        {
            var objUser = Context.Users.Find(_user.Id);
            if (objUser == null)
            {
                throw new EntityNotFoundException("User", _user.Id);
            }

            var emotionToFind = Context.Emotions.Find(data.EmotionId);
            if (emotionToFind == null)
            {
                throw new EntityNotFoundException("Emotions", data.EmotionId);
            }

            var objArt = Context.Articles.Find(data.ArticleId);
            if (objArt == null)
            {
                throw new EntityNotFoundException("Articles", data.ArticleId);
            }



            var objToDelete = Context.ArticleUserEmotions
                            .Where(x => x.EmotionId == data.EmotionId &&
                                        x.UserId == _user.Id &&    //IZ APP USERA 
                                        x.ArticleId == data.ArticleId)
                                        .FirstOrDefault();
            if (objToDelete == null)
            {
                throw new DeleteButNotExistsErrorException();
            }

            Context.ArticleUserEmotions.Remove(objToDelete);

            Context.SaveChanges();
        }
    }
}
