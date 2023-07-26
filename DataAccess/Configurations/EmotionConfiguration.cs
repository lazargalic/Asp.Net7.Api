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
    public class EmotionConfiguration : IEntityTypeConfiguration<Emotion>
    {
        public void Configure(EntityTypeBuilder<Emotion> builder)
        {
            builder.Property(x => x.NameEmotion).HasMaxLength(80).IsRequired();
            builder.HasIndex(x => x.NameEmotion).IsUnique();
            //builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.ImagePath).HasMaxLength(80);
            builder.Property(x => x.IsActive).HasDefaultValue(true);

        builder.HasMany(x => x.ArticleUserEmotions).WithOne(x => x.Emotion).HasForeignKey(x => x.EmotionId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
