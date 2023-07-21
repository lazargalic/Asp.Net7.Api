using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User : Entity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? IdentityNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
         
        public virtual Role Role { get; set; }
        public virtual ICollection<UserCompany> UserCompanys { get; set; } = new List<UserCompany>();
        public virtual ICollection<ArticleUserEmotion> ArticleUserEmotions { get; set; } = new List<ArticleUserEmotion>();
        public virtual ICollection<CommentArticle> CommentArticles { get; set; } = new List<CommentArticle>();
        public virtual ICollection<Article> Articles { get; set; } = new List<Article>();
        public virtual ICollection<AllUserUseCase> AllUserUseCases { get; set; } = new List<AllUserUseCase>();
    }


}
