using BusinessModels;
using DataAccessLayer.Models;
using DataAccessLayer.Repository.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Authentication;

namespace ServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration configuration;

        private IAuthenticationDaoImpl authenticationDaoImpl;
        private IJwtTokenManager jwtTokenManager;

        public LoginController(IAuthenticationDaoImpl authenticationDaoImpl, IConfiguration configuration, IJwtTokenManager _jwtmanager)
        {
            this.authenticationDaoImpl = authenticationDaoImpl;
            this.configuration = configuration;
            this.jwtTokenManager = _jwtmanager;
        }


        [HttpPost]

        public IActionResult LoginUser(LoginModel cred)
        {
            bool res = authenticationDaoImpl.IsAuthenticatedUser(cred);
            if (!res) return this.NotFound("Not found");
            var tokenval = jwtTokenManager.GenerateJwt(cred);

            return this.Ok(new { token = tokenval });
        }

        [HttpPost]
        [Route("admin")]
        public IActionResult LoginAdmin(LoginModel cred)
        {
            bool res = authenticationDaoImpl.IsAuthenticatedAdmin(cred);
            if (!res) return this.NotFound("Not found");
            var tokenval = jwtTokenManager.GenerateJwt(cred);

            return this.Ok(new { token = tokenval });
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
