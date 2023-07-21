using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CategoryDimension : Base
    {
        public string Dimension { get; set; }
        public float Price { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Article> Articles { get; set; } = new List<Article>();
        public virtual ICollection<CommentArticle> CommentArticles { get; set; } = new List<CommentArticle>();
    }
}
