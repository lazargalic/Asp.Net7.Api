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
    public class CategoryCommentConfiguration : IEntityTypeConfiguration<CategoryComment>
    {
        public void Configure(EntityTypeBuilder<CategoryComment> builder)
        {
            builder.Property(x => x.NameCategoryComment).HasMaxLength(80).IsRequired();
            builder.HasIndex(x => x.NameCategoryComment).IsUnique();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.StylePath).HasMaxLength(245); //ne mora required zbog pocetka pravljenja app
            builder.Property(x => x.IsActive).HasDefaultValue(true);

            builder.HasMany(x => x.CommentArticles).WithOne(x => x.CategoryComment).HasForeignKey(x => x.CategoryCommentId).OnDelete(DeleteBehavior.Restrict);


        }
    }
}
