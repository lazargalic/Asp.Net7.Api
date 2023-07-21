using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Dto
{
    public class CreateArticleNonRegisteredUserDto
    {
        public CreatingArticle ArticleToAdd { get; set; }
        public NonRegisteredUser NonRegisteredUserToAdd { get; set; }
         
    }

    public class CreateArticleRegisteredUserDto
    {
        public CreatingArticle ArticleToAdd { get; set; }
    }


    public class NonRegisteredUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class CreatingArticle 
    {
        public string NameArticle { get; set; }
        public string Description { get; set; }
        public string? AdditionalDescription { get; set; }
        public string? Quote { get; set; }
        public string? MainContent { get; set; }
        public DateTime Beggin { get; set; }
        public DateTime End { get; set; }
        //public int? NonRegisteredUserId { get; set; }//Ovo sami dodajemo  za non Registered kad se insertuje
        public int CategoryDimensionId { get; set; }
        public int CategoryDesignArticleId { get; set; }
  
        public int TownshipId { get; set; }
        public string? MainPicturePath { get; set; }
        public IEnumerable<AddMoreImagesToArticles>? MoreImages { get; set; } = new List<AddMoreImagesToArticles>();
    }

    public class AddMoreImagesToArticles
    {
        public string ImagePath { get; set; }
    }

    public class DeleteArticleDto
    {
        public int IdArticle { get; set; }
    }
}
