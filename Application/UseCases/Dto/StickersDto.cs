using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Dto
{
    public class CreateStickersDto
    {
        public string NameSticker { get; set; }
        public string PathSticker { get; set; }
    }

    public class GetStickersDto
    {
        public int Id { get; set; }
        public string NameSticker { get; set; }
        public string PathSticker { get; set; }
    }

    public class EditStickerDto
    {
        public int Id { get; set; }
        public string NewNameSticker { get; set; }
        public string NewPathSticker { get; set; }
    }


}
