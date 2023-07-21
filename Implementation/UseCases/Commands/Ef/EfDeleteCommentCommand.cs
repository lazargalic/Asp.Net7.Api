using Application;
using Application.Exceptions;
using Application.UseCases.Commands;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Commands.Ef
{
    public class EfDeleteCommentCommand : EfUseCase, IDeleteCommentCommand
    {
        private IApplicationUser User { get; }
        public EfDeleteCommentCommand(Asp2023DbContext context, IApplicationUser user) : base(context)
        {
            User = user;
        }

        public int Id => 29;

        public string Name => "Brisanje komentara";

        public string Description => "";

        public void Execute(int data)
        {
            var executor = Context.Users.Include(x => x.Role).FirstOrDefault(x => x.Id == User.Id);

            string executorRole = "";
            if (executor != null) { executorRole = executor.Role.NameRole; }

            CommentArticle? commentToDelete = null;

            if (executorRole != "Administrator")
            {
                commentToDelete = Context.CommentArticles.
                       FirstOrDefault(x => x.Id == data && x.UserId == User.Id);
            }
            else
            {
                commentToDelete = Context.CommentArticles.FirstOrDefault(x => x.Id == data);
            }


            if (commentToDelete == null)
            {
                throw new EntityNotFoundException("VASIH: Komentara", data);
            }

            if (executor != null && executor.Role.NameRole != "Administrator")
            {
                if (commentToDelete.UserId != User.Id)
                {
                    throw new ForbiddenExecutionException(this.Name, User.Identity);
                }
            }

            try
            {
                Context.Remove(commentToDelete);
                Context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new EntiyHasRestrictRelationships();
            }


        }
    }
}
