using System;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using eShop_Backend.Core.Entities;

namespace eShop_Backend.Utils
{
    public class AuthTokenHandler : IAuthTokenHandler
    {
        private readonly IConfiguration configuration;

        public AuthTokenHandler(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public bool CheckValidToken(string token)
        {
            throw new NotImplementedException();
        }

        public string CreateToken(User user)
        {
            Claim[] claims ={
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Email)
            };
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token"]));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            SecurityTokenDescriptor tokenDesc = new SecurityTokenDescriptor();
            tokenDesc.Subject = new ClaimsIdentity(claims);
            tokenDesc.SigningCredentials = creds;
            tokenDesc.Expires = DateTime.Now.AddDays(1);

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDesc);

            return tokenHandler.WriteToken(token); ;
        }
    }
}
