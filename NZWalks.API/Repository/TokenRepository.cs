using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using NZWalks.API.Repository.RepositoryInterface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NZWalks.API.Repository
{
    public class TokenRepository : IRepositoryAuth
    {
        private readonly IConfiguration configuration;

        public TokenRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string createJWTToken(IdentityUser identityUser, List<string> roles)
        {
            //create claims
            var claim = new List<Claim>();
            claim.Add(new Claim(ClaimTypes.Email, identityUser.Email));
            foreach (var role in roles)
            {
                claim.Add(new Claim(ClaimTypes.Role, role));
            }
            //create credentials
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwt:key"]));
            var credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                configuration["jwt:Issuer"],
                configuration["jwt:Audience"],
                claim,
                expires:DateTime.Now.AddMinutes(15),
                signingCredentials:credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
