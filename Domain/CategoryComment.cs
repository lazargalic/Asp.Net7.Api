using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CategoryComment : Base
    {
        public string NameCategoryComment { get; set; }
        public float Price { get; set; }
        public string StylePath { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<CommentArticle> CommentArticles { get; set; } = new List<CommentArticle>();
    }
}
