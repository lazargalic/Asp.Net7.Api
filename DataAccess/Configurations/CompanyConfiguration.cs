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
    public class CompanyConfiguration : EntityConfiguration<Company>
    {
        public override void MyOverride(EntityTypeBuilder<Company> builder)
        {
            builder.Property(x => x.NameCompany).HasMaxLength(115).IsRequired();
            builder.HasIndex(x => x.NameCompany).IsUnique();

            builder.HasMany(x=>x.UserCompany).WithOne(x=>x.Company).HasForeignKey(x=>x.CompanyId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
