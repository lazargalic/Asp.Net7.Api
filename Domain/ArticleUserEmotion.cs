using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ArticleUserEmotion
    {
        public int ArticleId { get; set; }   //kompozitni
        public int UserId { get; set; }      //kompozitni
        public int EmotionId { get; set; }   //logika da ako vec postoji reakcija da se samo updatuje 

        public virtual Article Article { get; set; }
        public virtual User User { get; set; }
        public virtual Emotion Emotion { get; set; }


    }
}
