using API.Core.ImagesDto;
using API.Core.TokenStorage;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Core
{
    public class JwtManager
    {
        private readonly Asp2023DbContext context;
        private readonly ITokenStorage _storage;
        private readonly string _issuer;
        private readonly string _key;
        private readonly int _minutes;

        public JwtManager(Asp2023DbContext context, string issuer, string key, int minutes, ITokenStorage storage)
        {
            this.context = context;
            this._storage = storage;
            _issuer = issuer;
            _key = key;
            _minutes = minutes;
        }

        public string MakeToken(string email, string password)
        {
            
            var user = context.Users.Include(x => x.AllUserUseCases)
                .FirstOrDefault(x => x.Email == email);

            if (user == null)
            {
                throw new UnauthorizedAccessException();  //c# 
            }

            var valid = BCrypt.Net.BCrypt.Verify(password, user.Password);

            if (!valid)
            {
                throw new UnauthorizedAccessException();  //c# 
            }

            var actor = new JwtUser
            {
                Id = user.Id,
                RoleId = user.RoleId,
                UseCaseIds = user.AllUserUseCases.Select(x => x.UseCaseId).ToList(),
                Identity = user.FirstName + " " + user.LastName,
                Email = user.Email
            };


            var tokenId = Guid.NewGuid().ToString();
            _storage.AddToken(tokenId);

            var claims = new List<Claim>  
            {
                new Claim(JwtRegisteredClaimNames.Jti, tokenId, ClaimValueTypes.String, _issuer),
                new Claim(JwtRegisteredClaimNames.Iss, _issuer),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, _issuer),
                new Claim("UserId", actor.Id.ToString(), ClaimValueTypes.String, _issuer),
                new Claim("UseCases", JsonConvert.SerializeObject(actor.UseCaseIds)), //NewToneJson
                new Claim("Email", actor.Email),
                new Claim("RoleId", actor.RoleId.ToString()),
                new Claim("Identity", actor.Identity),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: "Any",
                claims: claims,
                notBefore: now,
                expires: now.AddMinutes(_minutes),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
