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
    public class CommentArticleConfiguration : EntityConfiguration<CommentArticle>
    {
        public override void MyOverride(EntityTypeBuilder<CommentArticle> builder)
        {
            builder.Property(x => x.Content).HasMaxLength(245);

/*            builder.HasOne(x => x.Sticker).WithMany(x => x.CommentArticle).HasForeignKey(x => x.StickerId).OnDelete(DeleteBehavior.Restrict);*/

            builder.HasMany(x => x.ChildComments).WithOne(x => x.ParentComment).HasForeignKey(x => x.ParrentCommentId).OnDelete(DeleteBehavior.Restrict);

            /*           builder.HasOne(x => x.CommentArticleSticker).WithOne(x => x.CommentArticle).HasForeignKey(x => x.CommentArticleStickerId).OnDelete(DeleteBehavior.Restrict);*/

        }
    }
}
