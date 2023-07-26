using Application;
using Application.Exceptions;
using Application.UseCases.Commands;
using Application.UseCases.Dto;
using DataAccess;
using Implementation.Payments.Calculator;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Ef
{
    public class EfUserAddCommentCommand : EfUseCase, IAddCommentRegisteredUserCommand
    {
        private IApplicationUser userr;
        private CalculateTotalPrice Calculator { get; }
        public EfUserAddCommentCommand(Asp2023DbContext context, IApplicationUser user, CalculateTotalPrice calculator) : base(context)
        {
            userr = user;
            Calculator = calculator;
        }

        public int Id => 21;

        public string Name => "Dodavanje komentara";

        public string Description => "";

        public void Execute(AddCommentUserDto data)
        {
            var objUserId = Context.Users.Find(userr.Id);
            if(objUserId == null)
            {
                throw new EntityNotFoundException("User", userr.Id);
            }

            var objArticleId = Context.Articles.Find(data.ArticleId);

            if (objArticleId == null)
            {
                throw new EntityNotFoundException("Articles", data.ArticleId);
            }


            var objSticker = Context.Stickers.Find(data.StickerId);
            if (data.StickerId != null && data.StickerId!=0)
            {
                if (objSticker == null)
                {
                    throw new EntityNotFoundException("Stickers", (int)data.StickerId);
                }
            }

            if(string.IsNullOrEmpty(data.Content) && objSticker == null)
            {
                throw new EmptyCommentException();
            }

            if (data.ParrentCommentId != null && data.ParrentCommentId != 0)
            {

                int toNonNullabileInt = (int)data.ParrentCommentId;

                var objparrent = Context.CommentArticles.Include(x=>x.ParentComment).  //Ovo mi je falilo
                    Where(x => x.Id == toNonNullabileInt).FirstOrDefault();

                if (objparrent == null)
                {
                    throw new EntityNotFoundException("Parrent Comment", data.ParrentCommentId.Value);
                }


                var toFindInt = objparrent.ParrentCommentId;

                if(objparrent.ArticleId != data.ArticleId)
                {
                    throw new EntityNotFoundException("Roditeljski Articles", data.ArticleId);
                }

                if (toFindInt != null)
                {
                    throw new BadParrentExecption();
                }

            }



            //JednoUgnjezdavanjeKomentara samo provera ! 

            var cattDimId = Context.CategoryDimensions.Find(data.CategoryDimensionId);
            if (cattDimId == null)
            {
                throw new EntityNotFoundException("CategoryDimensions", data.CategoryDimensionId);
            }

            var cattComId = Context.CategoryComments.Find(data.CategoryCommentId);
            if (cattComId == null)
            {
                throw new EntityNotFoundException("CategoryComments", data.CategoryCommentId);
            }


            Context.CommentArticles.Add(new Domain.CommentArticle
            {
                Content=data.Content,
                ParrentCommentId=data.ParrentCommentId == 0 ? null : data.ParrentCommentId,
                UserId=userr.Id,
                ArticleId=data.ArticleId,
                CategoryDimensionId=data.CategoryDimensionId,
                CategoryCommentId=data.CategoryCommentId,
                StickerId=data.StickerId==0 ? null : data.StickerId,
                TotalPrice= Calculator.CalculateCommentTotalPrice(data)
            });

            Context.SaveChanges();
        }
    }
}
