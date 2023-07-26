using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Article : Entity
    {
        public int Id { get; set; }
        public string NameArticle { get; set; }
        public string MainPicturePath { get; set; }
        public string Description { get; set; }
        public string? AdditionalDescription { get; set; }
        public string? Quote { get; set; }
        public string? MainContent { get; set; }
        public DateTime Beggin { get; set; }
        public DateTime End { get; set; }
        public int? UserId { get; set; }
        public int CategoryDimensionId { get; set; }
        public int CategoryDesignArticleId { get; set; }
        public int? NonRegisteredUserId { get; set; }
        public int TownshipId { get; set; }
        public double? TotalPrice { get; set; }

        public virtual User? User { get; set; }
        public virtual Township Township { get; set; }
        public virtual NonRegisteredUser? NonRegisteredUser { get; set; }  //
        public virtual CategoryDimension CategoryDimension { get; set; }
        public virtual CategoryDesignArticle CategoryDesignArticle { get; set; }
        public virtual ICollection<ArticleImage> ArticleImages { get; set; } = new List<ArticleImage>();
        public virtual ICollection<CommentArticle> CommentArticles { get; set; } = new List<CommentArticle>(); 
        public virtual ICollection<ArticleUserEmotion> ArticleUserEmotions { get; set; } = new List<ArticleUserEmotion>(); 

    }
}
