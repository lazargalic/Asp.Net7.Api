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
    public class CategoryDimensionConfiguration : IEntityTypeConfiguration<CategoryDimension>
    {
        public void Configure(EntityTypeBuilder<CategoryDimension> builder)
        {
            builder.Property(x => x.Dimension).HasMaxLength(80).IsRequired();
            builder.HasIndex(x => x.Dimension).IsUnique();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.IsActive).HasDefaultValue(true);

            builder.HasMany(x => x.CommentArticles).WithOne(x => x.CategoryDimension).HasForeignKey(x => x.CategoryDimensionId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Articles).WithOne(x => x.CategoryDimension).HasForeignKey(x => x.CategoryDimensionId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
