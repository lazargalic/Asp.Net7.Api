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
    public class StickerConfiguration : IEntityTypeConfiguration<Sticker>
    {
        public void Configure(EntityTypeBuilder<Sticker> builder)
        {

            builder.Property(x => x.NameSticker).HasMaxLength(80).IsRequired();
            builder.HasIndex(x => x.NameSticker).IsUnique();
            builder.Property(x => x.StickerPath).HasMaxLength(240).IsRequired();
            builder.Property(x => x.IsActive).HasDefaultValue(true);

            builder.HasMany(x => x.CommentArticle).WithOne(x => x.Sticker).HasForeignKey(x => x.StickerId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
