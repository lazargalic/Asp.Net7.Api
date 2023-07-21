using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Dto
{
    public class EmotionDto
    {
        public int Id { get; set; }
        public string NameEmotion { get; set; }
        public string ImagePath { get; set; }
        public float Price { get; set; }
    }

    public class CreateEmotionDto
    {
        public string NameEmotion { get; set; }
        public string ImagePath { get; set; }
        public float Price { get; set; }
    }



    public class EditEmotionDto
    {
        public int Id { get; set; }
        public string NewNameEmotion { get; set; }
        public string NewImagePath { get; set; }
       // public float NewPrice { get; set; } //Ne menjati Cenu zbog Kasnijeg uvida u placanje
    }

}
