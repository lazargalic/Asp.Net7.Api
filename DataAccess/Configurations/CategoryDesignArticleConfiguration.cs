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
    public class CategoryDesignArticleConfiguration : IEntityTypeConfiguration<CategoryDesignArticle>
    {
        public void Configure(EntityTypeBuilder<CategoryDesignArticle> builder)
        {
            builder.Property(x => x.NameDesign).HasMaxLength(80).IsRequired();
            builder.HasIndex(x => x.NameDesign).IsUnique();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.DesignPath).HasMaxLength(240).IsRequired();
            builder.Property(x => x.IsActive).HasDefaultValue(true);

            builder.HasMany(x => x.Articles).WithOne(x => x.CategoryDesignArticle).HasForeignKey(x => x.CategoryDesignArticleId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
