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
    public class NonRegisteredUserConfiguration : IEntityTypeConfiguration<NonRegisteredUser>
    {
        public void Configure(EntityTypeBuilder<NonRegisteredUser> builder)
        {
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(120);
            builder.Property(x => x.PhoneNumber).HasMaxLength(20);

            builder.HasOne(x => x.Article).WithOne(x => x.NonRegisteredUser).OnDelete(DeleteBehavior.Restrict); //*******

            /*            builder.HasOne(x=>x.Article).WithOne(x=>x.NonRegisteredUser).HasForeignKey(ArticleId).OnDelete(DeleteBehavior.Restrict);*/
        }
    }
}
