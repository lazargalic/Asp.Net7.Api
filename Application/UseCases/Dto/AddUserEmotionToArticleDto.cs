using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Dto
{
    public class AddUserEmotionToArticleDto
    {
        public int ArticleId { get; set; }
        public int EmotionId { get; set; }
    }

    public class DeleteUserEmotionToArticleDto
    {
        public int ArticleId { get; set; }
        public int EmotionId { get; set; }
    }

}
