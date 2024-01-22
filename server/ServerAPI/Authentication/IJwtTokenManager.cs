using DataAccessLayer.Models;

namespace ServerAPI.Authentication
{
    public interface IJwtTokenManager
    {
        string GenerateJwt(LoginModel user);
    }
}
