using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class UserConfiguration : EntityConfiguration<User>
    {
        public override void MyOverride(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(120);
            builder.Property(x => x.Password).HasMaxLength(120).IsRequired();
            builder.Property(x => x.PhoneNumber).HasMaxLength(20);
            builder.Property(x => x.IdentityNumber).HasMaxLength(40);
            //builder.Property(x => x.IsActive).HasDefaultValue(true);

            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.FirstName);
            builder.HasIndex(x => x.LastName);
            builder.Property(x => x.VerificationCode).HasMaxLength(340);

            builder.HasMany(x => x.Articles).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.CommentArticles).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.ArticleUserEmotions).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.UserCompanys).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.AllUserUseCases).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
            
        }
    }
}
