using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataAccess
{
    public class Asp2023DbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-MCLUKEP\\SQLEXPRESS;Initial Catalog=AspProjekat2023;Integrated Security=True;TrustServerCertificate=True");


 

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //kompozitni kljucevi
            modelBuilder.Entity<ArticleUserEmotion>().HasKey(x => new { x.ArticleId, x.UserId });
            modelBuilder.Entity<AllUserUseCase>().HasKey(x => new { x.UserId , x.UseCaseId });

            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }

        //save changes
        public override int SaveChanges()
        {
            //context.Entry(objToDeactive).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            foreach (var item in ChangeTracker.Entries())  //Item u Entries  ima .Entity i .State
            {
                Entity itemToCast = item.Entity as Entity;
                if (itemToCast != null)
                {
                    if (item.State == EntityState.Deleted)
                    {
                         item.State = EntityState.Modified;
                        itemToCast.DeletedAt = DateTime.Now;
                        
                        var user = itemToCast as User;
                        if (user != null)
                        {
                            user.IsActive = false;
                        }
                    }
                    if (item.State == EntityState.Added)
                    {
                        itemToCast.CreatedAt = DateTime.Now;
                    }
                    if (item.State == EntityState.Modified)
                    {
                        itemToCast.LastUpdatedAt = DateTime.Now;
                    }

                }
            }


            return base.SaveChanges();
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleImage> ArticleImages { get; set; }
        public DbSet<ArticleUserEmotion> ArticleUserEmotions { get; set; }
        public DbSet<CategoryComment> CategoryComments { get; set; }
        public DbSet<CategoryDimension> CategoryDimensions { get; set; }
        public DbSet<CategoryDesignArticle> CategoryDesignArticles { get; set; }
        public DbSet<CommentArticle> CommentArticles { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Emotion> Emotions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Sticker> Stickers { get; set; }
        public DbSet<Township> Townships { get; set; }
        public DbSet<UseCaseRole> UseCaseRoles { get; set; }  //Defaultne
        public DbSet<User> Users { get; set; }
        public DbSet<UserCompany> UserCompanies { get; set; }
        public DbSet<AllUserUseCase> AllUserUseCases { get; set; }
        public DbSet<NonRegisteredUser> NonRegisteredUsers { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        

    }
}

