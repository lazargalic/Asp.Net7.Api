using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Emotion : Base
    {
        public string NameEmotion { get; set; }
        public string ImagePath { get; set; }
        public float Price { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<ArticleUserEmotion> ArticleUserEmotions { get; set; } = new List<ArticleUserEmotion>();
    }
}
