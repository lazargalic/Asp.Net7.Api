using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Sticker : Base
    {
        public string NameSticker { get; set; }
        public string StickerPath { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<CommentArticle> CommentArticle { get; set; } = new List<CommentArticle>();
    }
}
