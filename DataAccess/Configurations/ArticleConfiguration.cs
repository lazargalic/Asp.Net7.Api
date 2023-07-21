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
    public class ArticleConfiguration : EntityConfiguration<Article>
    {
        public override void MyOverride(EntityTypeBuilder<Article> builder)
        {
            builder.Property(x=>x.NameArticle).IsRequired().HasMaxLength(100);
            builder.HasIndex(x => x.NameArticle); //Nije unique
            builder.Property(x=>x.MainPicturePath).IsRequired().HasMaxLength(220);
            builder.Property(x=>x.Description).IsRequired().HasMaxLength(745);
            builder.Property(x=>x.AdditionalDescription).HasMaxLength(445);
            builder.Property(x=>x.Quote).HasMaxLength(385);
            builder.Property(x=>x.MainContent).HasMaxLength(6445);
            builder.Property(x => x.Beggin).IsRequired();
            builder.HasIndex(x => x.Beggin);
            builder.Property(x => x.End).IsRequired();
            builder.HasIndex(x => x.End);

            builder.HasMany(x => x.ArticleImages).WithOne(x => x.Article).HasForeignKey(x => x.ArticleId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.CommentArticles).WithOne(x => x.Article).HasForeignKey(x => x.ArticleId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.ArticleUserEmotions).WithOne(x => x.Article).HasForeignKey(x => x.ArticleId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
