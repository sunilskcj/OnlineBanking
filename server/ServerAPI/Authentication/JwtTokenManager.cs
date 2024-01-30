using DataAccessLayer.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace ServerAPI.Authentication
{
    public class JwtTokenManager : IJwtTokenManager
    {
        private IConfiguration configuration;
        public JwtTokenManager(IConfiguration _configuration)
        {
            this.configuration = _configuration;
        }
        public string GenerateJwt(LoginModel cred)
        {
            string secretKey = this.configuration["Jwt:Key"];
            byte[] secrectKeyByteArray = Encoding.UTF8.GetBytes(secretKey);
            SymmetricSecurityKey tokenKey = new SymmetricSecurityKey(secrectKeyByteArray);
            SigningCredentials signingCredentials = new SigningCredentials(tokenKey, SecurityAlgorithms.HmacSha256);
            Claim userNameBasedClaim = new Claim(ClaimTypes.Name, cred.CustomerId.ToString());

            Claim[] userClaims = new Claim[] { userNameBasedClaim };
            ClaimsIdentity identiy = new ClaimsIdentity(userClaims);
            SecurityTokenDescriptor tokeDescriptor = new SecurityTokenDescriptor
            {
                Issuer = this.configuration["Jwt:Issuer"],
                Audience = this.configuration["Jwt:Audience"],
                IssuedAt = DateTime.Now,
                Subject = identiy,
                Expires = DateTime.Now.AddMinutes(45),
                SigningCredentials = signingCredentials
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = tokenHandler.CreateToken(tokeDescriptor);
            string token = tokenHandler.WriteToken(securityToken);
            return token;

        }

        
    }
}
