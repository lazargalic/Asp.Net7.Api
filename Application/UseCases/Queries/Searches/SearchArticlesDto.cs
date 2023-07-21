using Application.UseCases.PaginationDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Queries.Searches
{
    public class SearchArticlesDto : BasePaginationSearch
    {
        public string? NameArticle { get; set; }
        public string? DescriptionKeyword { get; set; }
        public DateTime? Beggin { get; set; }
        public DateTime? End { get; set; }
        public int? CountryId { get; set; }
        public IEnumerable<int>? Townships { get; set; } = new List<int>();
        public int? CategoryDimensionId { get; set; }
    }

    public class GetArticlesCommentDto
    {
        public int Id { get; set; }
        public string NameArticle { get; set; }
        public string MainPicturePath { get; set; }
        public string Description { get; set; }
         public string? AdditionalDescription { get; set; }
         public string? Quote { get; set; }
         public string? MainContent { get; set; }
        public DateTime Beggin { get; set; }
        public DateTime End { get; set; }
        public int EmotionsNumber { get; set; }
        public int CategoryDimensionId { get; set; }
        public AuthorDto Author { get; set; }
        public TownshipDto Township { get; set; }
         public  EmotionDto2  Emotions { get; set; }
        public IEnumerable<CommenttDto> Comments { get; set; } = new List<CommenttDto>();
        public DateTime? DeletedAt { get; set; }   
         public DateTime? CreatedAt { get; set; }   
         public DateTime? LastUpdatedAt { get; set; }   

    }

    public class CommenttDto
    {
        public int IdComment { get; set; }
        public string Content { get; set; }
        public int? StickerId { get; set; }
        public string User { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<CommenttDto> ChildCommentts { get; set; } = new List<CommenttDto>();

    }

    public class EmotionDto2
    {
        public IEnumerable<string> Love { get; set; } = new List<string>();
        public IEnumerable<string> Fire { get; set; }  = new List<string>();
        public IEnumerable<string> Dislike { get; set; } = new List<string>();
    }
 

    public class TownshipDto
    {
        public int Id { get; set; }
        public string NameTownship { get; set; }
        public int IdCountry { get; set; }
        public string NameCountry { get; set; }
    }

    public class AuthorDto
    {
        public int Id { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}

