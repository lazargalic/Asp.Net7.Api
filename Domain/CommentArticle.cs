using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CommentArticle : Entity
    {
        public int Id { get; set; }
        public string? Content { get; set; }  //Ako je sticker komentar, onda ne mora content logika
        public int? ParrentCommentId { get; set; }
        public int UserId { get; set; }
        public int ArticleId { get; set; }
        public int CategoryCommentId { get; set; }
        public int? StickerId { get; set; }
        public int CategoryDimensionId { get; set; }
        //public int? CommentArticleStickerId { get; set; }

        public virtual User User { get; set; }
        public virtual Article Article { get; set; }
        public virtual Sticker? Sticker { get; set; } //u biznis logiki za sada samo po jedan stiker omoguciti

        //public virtual CommentArticleSticker CommentArticleSticker { get; set; }
        public virtual CategoryComment CategoryComment { get; set; }
        public virtual CategoryDimension CategoryDimension { get; set; }
        public virtual CommentArticle? ParentComment { get; set; }
        public virtual ICollection<CommentArticle>? ChildComments { get; set;} = new List<CommentArticle>(); 

    }
}
