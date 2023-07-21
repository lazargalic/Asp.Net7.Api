using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CategoryDesignArticle : Base
    {
        public string NameDesign { get; set; }
        public float Price { get; set; }
        public string DesignPath { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Article> Articles { get; set; } = new List<Article>();
    }
}
