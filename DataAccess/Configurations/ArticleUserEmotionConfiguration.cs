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
    public class ArticleUserEmotionConfiguration : IEntityTypeConfiguration<ArticleUserEmotion>
    {
        public void Configure(EntityTypeBuilder<ArticleUserEmotion> builder)
        {
            
        }
    }
}
