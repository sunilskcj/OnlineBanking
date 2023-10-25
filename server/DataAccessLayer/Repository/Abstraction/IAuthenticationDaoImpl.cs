using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer.Repository.Abstraction
{
    public interface IAuthenticationDaoImpl
    {
        bool IsAuthenticatedUser(LoginModel loginModel);
        bool IsAuthenticatedAdmin(LoginModel loginModel);
        bool ChangePassword(int id, string currentPassword, string newPassword);
    }
}
