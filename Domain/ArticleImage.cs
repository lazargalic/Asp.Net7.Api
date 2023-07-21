using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ArticleImage : Base
    {
        public int ArticleId { get; set; }
        public string ImagePath { get; set; }
        public string? Alt { get; set; }

        public virtual Article Article { get; set; }
    }
}
