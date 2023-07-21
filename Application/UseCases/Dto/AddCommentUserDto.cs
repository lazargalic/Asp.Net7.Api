using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Dto
{
    public class AddCommentUserDto
    {
        public string Content { get; set; }
        public int? ParrentCommentId { get; set; }
        public int ArticleId { get; set; }
        public int CategoryCommentId { get; set; }
        public int CategoryDimensionId { get; set; }
        public int? StickerId { get; set; }
    }

    public class ReactedEmotionIdToPost
    {
        public int? IdEmotion { get; set; }
        public string? NameEmotion { get; set; }
    }
}
