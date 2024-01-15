using BusinessModels;
using DataAccessLayer.Models;
using DataAccessLayer.Repository.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration configuration;

        private IAuthenticationDaoImpl authenticationDaoImpl;

        public LoginController(IAuthenticationDaoImpl authenticationDaoImpl, IConfiguration configuration)
        {
            this.authenticationDaoImpl = authenticationDaoImpl;
            this.configuration = configuration;
        }


        [HttpPost]

        public IActionResult LoginUser(LoginModel cred)
        {
            bool res = authenticationDaoImpl.IsAuthenticatedUser(cred);
            if (!res) return this.NotFound("Not found");
            var tokenval = GenerateJwt(cred);

            return this.Ok(new { token = tokenval });
        }

        [HttpPost]
        [Route("admin")]
        public IActionResult LoginAdmin(LoginModel cred)
        {
            bool res = authenticationDaoImpl.IsAuthenticatedAdmin(cred);
            if (!res) return this.NotFound("Not found");
            var tokenval = GenerateJwt(cred);

            return this.Ok(new { token = tokenval });
        }

        private string GenerateJwt(LoginModel cred)
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

        [HttpPut]
        [Route("changepassword")]
        public IActionResult ChangePassword([FromBody] ForgetCredentials forgetCredentials)
        {

            bool res = authenticationDaoImpl.ChangePassword(100020, "XTT6DLOU06M42", "1234567Sk");
            if (!res) return this.NotFound("Not found");
            return this.Ok("Password Updated");
        }


    }
}
