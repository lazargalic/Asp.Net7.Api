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
    public class AllUserUseCaseConfiguration : IEntityTypeConfiguration<AllUserUseCase>
    {
        public void Configure(EntityTypeBuilder<AllUserUseCase> builder)
        {

        }
    }
}
