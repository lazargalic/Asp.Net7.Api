using Application.UseCases.Dto;

namespace API.Core.ImagesDto
{
    public class Dtos
    {
        public class CreateArticleRegisteredUserDtoWithImages : CreateArticleRegisteredUserDto
        {
            public IFormFile MainPicture { get; set; }
            public IEnumerable<IFormFile>? MoreImages { get; set; } = new List<IFormFile>();
        }

        public class CreateArticleNonRegisteredUserDtoWithImages : CreateArticleNonRegisteredUserDto
        {
            public IFormFile MainPicture { get; set; }
            public IEnumerable<IFormFile>? MoreImages { get; set; } = new List<IFormFile>();
        }

        public class EditArticleWithImage : EdititingArticle
        {
            public IFormFile? MainPicture { get; set; }
            //public IEnumerable<IFormFile>? MoreImages { get; set; } = new List<IFormFile>();
        }


    }
}
