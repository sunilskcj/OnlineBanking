using BusinessModels;
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
    public class PayeeDaoImpl : IPayeeDaoImpl
    {
        public List<PayeeModel> FetchAllAccount(int id)
        {
            List<PayeeModel> businessDetails = null;
            try
            {
                using (var db = new BankingContext())
                {
                    DbSet<PayeeDetail> allAcc = db.PayeeDetails;
                    var matchingAccount = allAcc.Where(p => p.CustomerId == id);
                    if (matchingAccount != null && matchingAccount.Count() > 0)
                    {


                        businessDetails =
                            matchingAccount
                             .Select(
                                (PayeeDetail a) =>
                                     new PayeeModel
                                     {
                                         PayeeAccountNumber = a.PayeeAccountNumber,
                                         PayeeId = a.PayeeId,
                                         PayeeName = a.PayeeName,
                                         PayeeMobileNumber = a.PayeeMobileNumber,
                                         CustomerId = a.CustomerId,
                                     }
                             )
                             .ToList<PayeeModel>();

                    }
                }
                return businessDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public PayeeModel FetchAccountById(int id)
        {
            PayeeModel businessDetails = null;
            try
            {
                using (var db = new BankingContext())
                {
                    DbSet<PayeeDetail> alldetails = db.PayeeDetails;
                    var matchingAccount = alldetails.Where(p => p.CustomerId == id);
                    if (matchingAccount != null && matchingAccount.Count() > 0)
                    {


                        PayeeDetail a = matchingAccount.First<PayeeDetail>();
                        businessDetails = new PayeeModel
                        {

                            PayeeAccountNumber = a.PayeeAccountNumber,
                            PayeeId = a.PayeeId,
                            PayeeName = a.PayeeName,
                            PayeeMobileNumber = a.PayeeMobileNumber,
                            CustomerId = a.CustomerId,

                        };
                    }
                }
                return businessDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool InsertAccountField(PayeeModel a, int id)
        {
            int result = 0;
            try
            {
                using (var db = new BankingContext())
                {
                    DbSet<PayeeDetail> allAccount = db.PayeeDetails;
                    DbSet<AccountFields> Accountid = db.AccountFields;
                    var matchingAccount = Accountid.Where(p => p.CustomerId == id);
                    if (matchingAccount != null && matchingAccount.Count() > 0)
                    {
                        AccountFields p = matchingAccount.First<AccountFields>();

                        //var matchingPayeeAccount = p.Where((AccountFields payee) => payee.PayeeAccountNumber == a.PayeeAccountNumber);
                        //if (matchingAccount != null && matchingAccount.Count() > 0)
                        //{




                        PayeeDetail entityModelObject = new PayeeDetail
                        {


                            PayeeAccountNumber = a.PayeeAccountNumber,
                            PayeeId = a.PayeeId,
                            PayeeName = a.PayeeName,

                            CustomerId = p.CustomerId,

                        };
                        allAccount.Add(entityModelObject);
                        result = db.SaveChanges();
                        // }
                    }
                }
                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UpdateAccountField(PayeeModel a, int id)
        {

            int result = 0;
            try
            {
                using (var db = new BankingContext())
                {
                    DbSet<PayeeDetail> alldetails = db.PayeeDetails;
                    var matchingAccount = alldetails.Where(p => p.PayeeId == id);
                    if (matchingAccount != null && matchingAccount.Count() > 0)
                    {

                        PayeeDetail p = matchingAccount.First<PayeeDetail>();

                        p.PayeeAccountNumber = a.PayeeAccountNumber;
                        p.PayeeId = a.PayeeId;
                        p.PayeeName = a.PayeeName;
                        p.PayeeMobileNumber = a.PayeeMobileNumber;
                        p.CustomerId = a.CustomerId;

                        alldetails.Update(p);
                        result = db.SaveChanges();
                    }

                }

                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DeleteAccountFieldbyID(int id)
        {
            int res = 0;
            try
            {
                using (var db = new BankingContext())
                {
                    DbSet<PayeeDetail> alldetails = db.PayeeDetails;
                    var matchingAccount = alldetails.Where(p => p.PayeeId == id);
                    if (matchingAccount != null && matchingAccount.Count() > 0)
                    {
                        PayeeDetail p = matchingAccount.First<PayeeDetail>();
                        alldetails.Remove(p);
                        res = db.SaveChanges();
                    }
                }
                return res > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
