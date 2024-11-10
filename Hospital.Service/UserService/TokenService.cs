using Hospital.Data.Entities.Identity;
using Hospital.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Hospital.Service.UserService
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration configuration;
        private readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration configuration)
        {
            this.configuration = configuration;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"]));
        }

        public string GenerateToken(AppUser user, string roleName = "User")
        {


            var claims = new List<Claim>
            {
                new Claim("UserId",user.Id),
               new Claim(ClaimTypes.Name,user.UserName),
               new Claim(ClaimTypes.Email,user.Email),
               new Claim(ClaimTypes.Role,roleName)
            };
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = creds,
                Expires = DateTime.Now.AddDays(1)
            };
            var tokenHandlr = new JwtSecurityTokenHandler();

            var token = tokenHandlr.CreateToken(tokenDescriptor);

            return tokenHandlr.WriteToken(token);
        }
    }
}
