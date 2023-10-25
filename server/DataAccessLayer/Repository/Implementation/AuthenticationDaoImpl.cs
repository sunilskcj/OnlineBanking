using DataAccessLayer.Models;
using DataAccessLayer.Repository.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Implementation
{
    public class AuthenticationDaoImpl : IAuthenticationDaoImpl
    {
        public bool IsAuthenticatedUser(LoginModel loginModel)
        {
            try
            {
                using (var db = new BankingContext())
                {
                    DbSet<AccountFields> accdetails = db.AccountFields;
                    bool matchingAccountid = accdetails.Any(p => p.CustomerId == loginModel.CustomerId && p.Credential.NetBankingPassword == loginModel.NetBankingPassword);

                    if (matchingAccountid) return true;
                    else return false;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public bool IsAuthenticatedAdmin(LoginModel loginModel)
        {
            try
            {
                using (var db = new BankingContext())
                {
                    DbSet<AdminDetail> accdetails = db.AdminDetails;
                    bool matchingAccountid = accdetails.Any(p => p.AdminId == loginModel.CustomerId && p.AdminPassword == loginModel.NetBankingPassword);

                    if (matchingAccountid) return true;
                    else return false;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }


        public bool ChangePassword(int id, string currentPassword, string newPassword)
        {
            try
            {
                int res = 0;
                using (var db = new BankingContext())
                {
                    DbSet<AccountFields> accdetails = db.AccountFields;
                    var matchingAccountid = accdetails.Where(p => p.CustomerId == id);
                    if (matchingAccountid != null)
                    {
                        DbSet<BankCredential> accCreddetails = db.BankCredentials;
                        var matchingAccountCred = accCreddetails.Where(p => p.NetBankingPassword == currentPassword);
                        if (matchingAccountCred != null)
                        {

                            BankCredential credentials = matchingAccountCred.FirstOrDefault();
                            credentials.NetBankingPassword = newPassword;
                            accCreddetails.Add(credentials);
                            res = db.SaveChanges();
                        }
                    }

                    return res > 0;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

    }
}
