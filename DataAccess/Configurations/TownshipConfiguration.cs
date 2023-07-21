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
    public class TownshipConfiguration : IEntityTypeConfiguration<Township>
    {
        public void Configure(EntityTypeBuilder<Township> builder)
        {
            builder.Property(x => x.NameTownship).HasMaxLength(80).IsRequired();
            builder.HasIndex(x => x.NameTownship).IsUnique();

            builder.HasMany(x => x.Articles).WithOne(x => x.Township).HasForeignKey(x => x.TownshipId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
