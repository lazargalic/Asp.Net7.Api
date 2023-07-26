using Application;

namespace API.Core
{
    public class JwtUser : IApplicationUser
    {
        public string Identity { get; set; }
        public int Id { get; set; } 
        public int RoleId { get; set; } 
        public IEnumerable<int> UseCaseIds { get; set; } = new List<int>();
        public string Email { get; set; }
    }

    public class AnonymousUser : IApplicationUser
    {
        public string Identity => "Anonymous";
        public int Id => 0;
        public int RoleId => 0;
        public IEnumerable<int> UseCaseIds => new List<int> { 1, 9, 10, 11, 14, 16, 19, 22, 26, 31, 34}; //Dodati ulogu neulogovani korisnik i use casove
        public string Email => "anonymous@gmail.com";
    }
}
