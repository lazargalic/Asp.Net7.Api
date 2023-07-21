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
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.Property(x => x.NameCountry).HasMaxLength(130).IsRequired();
            builder.HasIndex(x => x.NameCountry).IsUnique();

            builder.HasMany(x=>x.Townships).WithOne(x=>x.Country).HasForeignKey(x=>x.CountryId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
