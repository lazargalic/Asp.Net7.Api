using Application;
using Application.Exceptions;
using Application.UseCases;
using Application.UseCases.Commands;
using Application.UseCases.Dto;
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
    public class EfDeleteArticleCommand : EfUseCase, IDeleteArticleCommand
    {
        private IApplicationUser User { get; }
        public EfDeleteArticleCommand(Asp2023DbContext context, IApplicationUser user) : base(context)
        {
            User = user;
        }

        public int Id => 28;

        public string Name => "Obrisi Post";

        public string Description => "";

        public void Execute(DeleteArticleDto data)
        {
            var executor = Context.Users.Include(x => x.Role).FirstOrDefault(x => x.Id == User.Id);

            string executorRole = "";
            if (executor != null) {  executorRole = executor.Role.NameRole; }

            Article? postToDelete = null;

            if(executorRole != "Administrator")
            {
                postToDelete = Context.Articles.
                       FirstOrDefault(x => x.Id == data.IdArticle && x.UserId == User.Id);
            }
            else
            {
                postToDelete = Context.Articles.FirstOrDefault(x => x.Id == data.IdArticle);
            }


            if (postToDelete == null)
            {
                throw new EntityNotFoundException("VASIH: Articles", data.IdArticle);
            }

            if (executor!= null && executor.Role.NameRole != "Administrator")
            {
                if(postToDelete.UserId != User.Id)
                {
                    throw new ForbiddenExecutionException(this.Name, User.Identity);
                }
            }

            try
            {
                Context.Remove(postToDelete);
                Context.SaveChanges();
            }
            catch(Exception e)
            {
                throw new EntiyHasRestrictRelationships();
            }

        }
    }
}
