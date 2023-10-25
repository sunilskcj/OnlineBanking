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
    public class TransactionDaoImpl : ITransactionDaoImpl
    {
        public List<TransactionModel> FetchAllAccount(int id)
        {
            List<TransactionModel> businessDetails = null;
            try
            {
                using (var db = new BankingContext())
                {

                    DbSet<TransactionDetail> allAcc = db.TransactionDetails;
                    var matchingAccount = allAcc.Where(p => p.CustomerId == id);
                    if (matchingAccount != null && matchingAccount.Count() > 0)
                    {

                        businessDetails =
                            matchingAccount
                             .Select(
                                (TransactionDetail a) =>
                                     new TransactionModel
                                     {
                                         TransactionReferenceId = a.TransactionReferenceId,
                                         Transactionamount = a.Transactionamount,
                                         TransactionDate = a.TransactionDate,
                                         ModeId = a.ModeId,
                                         Remark = a.Remark,
                                         CustomerId = a.CustomerId,
                                         PayeeId = a.PayeeId,

                                         AccountNumber = a.Customer.Credential.AccountNumber,
                                         PaymentStatus = a.PaymentStatus,
                                         PayeeAccountNumber = a.Customer.Credential.AccountNumber,

                                     }
                             )
                             .ToList<TransactionModel>();

                    }
                }
                return businessDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TransactionModel FetchAccountById(int id)
        {
            TransactionModel businessDetails = null;
            try
            {
                using (var db = new BankingContext())
                {
                    DbSet<TransactionDetail> alldetails = db.TransactionDetails;
                    var matchingAccount = alldetails.Where(p => p.TransactionReferenceId == id);
                    if (matchingAccount != null && matchingAccount.Count() > 0)
                    {


                        TransactionDetail a = matchingAccount.First<TransactionDetail>();
                        businessDetails = new TransactionModel
                        {

                            Transactionamount = a.Transactionamount,
                            TransactionDate = a.TransactionDate,
                            ModeId = a.ModeId,
                            Remark = a.Remark,
                            PayeeId = a.PayeeId,
                            CustomerId = a.CustomerId,

                            TransactionReferenceId = a.TransactionReferenceId,

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
        public List<TransactionModel> FetchAccountBystatus(string status, int id)
        {
            List<TransactionModel> businessDetails = null;
            try
            {
                using (var db = new BankingContext())
                {
                    DbSet<TransactionDetail> alldetails = db.TransactionDetails;

                    var matchingAccount = alldetails.Where(p => p.PaymentStatus == status);
                    if (matchingAccount != null && matchingAccount.Count() > 0)
                    {
                        businessDetails =
                               alldetails
                                .Select(
                                   (TransactionDetail a) =>
                                        new TransactionModel
                                        {
                                            TransactionReferenceId = a.TransactionReferenceId,
                                            Transactionamount = a.Transactionamount,
                                            TransactionDate = a.TransactionDate,
                                            ModeId = a.ModeId,
                                            Remark = a.Remark,
                                            CustomerId = a.CustomerId,
                                            PayeeId = a.PayeeId,

                                            AccountNumber = a.Customer.Credential.AccountNumber,
                                            PaymentStatus = a.PaymentStatus,
                                            PayeeAccountNumber = a.Customer.Credential.AccountNumber,

                                        }
                                )
                                .ToList<TransactionModel>();

                    }
                }
                return businessDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public int? InsertAccountField(TransactionModel a, int id)
        {
            int? result = 0;
            try
            {
                using (var db = new BankingContext())
                {
                    //DbSet<BankCredentials> alldetails = db.BankCredentials;
                    //var matchingAccount = alldetails.Where(p => p.AccountNumber == a.PayeeAccountNumber);


                    //if (matchingAccount != null && matchingAccount.Count() > 0)
                    //{
                    DbSet<AccountFields> allAccount = db.AccountFields;
                    var matchingAccount = allAccount.Where(p => p.CustomerId == id);
                    if (matchingAccount != null && matchingAccount.Count() > 0)
                    {
                        AccountFields p = matchingAccount.First<AccountFields>();




                        DbSet<TransactionDetail> allAccountTransa = db.TransactionDetails;
                        TransactionDetail entityModelObject = new TransactionDetail
                        {

                            Transactionamount = a.Transactionamount,
                            TransactionDate = DateTime.Now,
                            ModeId = a.ModeId,
                            Remark = a.Remark,
                            PayeeId = a.PayeeId,
                            CustomerId = id,
                            MaturityInstruction = a.MaturityInstruction,
                            PaymentStatus = "Pending",
                            TransactionReferenceId = GenerateReferenceID()

                        };

                        allAccountTransa.Add(entityModelObject);
                        db.SaveChanges();
                        result = entityModelObject.TransactionReferenceId;
                    }
                    // }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UpdateAccountField(TransactionModel a, int id)
        {

            int result = 0;
            try
            {
                using (var db = new BankingContext())
                {
                    DbSet<TransactionDetail> alldetails = db.TransactionDetails;
                    var matchingAccount = alldetails.Where(p => p.ModeId == id);
                    if (matchingAccount != null && matchingAccount.Count() > 0)
                    {

                        TransactionDetail p = matchingAccount.First<TransactionDetail>();


                        p.Transactionamount = a.Transactionamount;
                        p.TransactionDate = a.TransactionDate;
                        p.ModeId = a.ModeId;
                        p.Remark = a.Remark;



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
                    DbSet<TransactionDetail> alldetails = db.TransactionDetails;
                    var matchingAccount = alldetails.Where(p => p.TransactionReferenceId == id);
                    if (matchingAccount != null && matchingAccount.Count() > 0)
                    {
                        TransactionDetail p = matchingAccount.First<TransactionDetail>();
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


        Random rnd = new Random(8);
        private int? GenerateReferenceID()
        {

            bool loop = true;

            do
            {
                int number = rnd.Next();
                using (var db = new BankingContext())
                {

                    DbSet<TransactionDetail> alldetails = db.TransactionDetails;
                    var matchingAccount = alldetails.Where(p => p.TransactionReferenceId == number);
                    if (matchingAccount == null)
                    {
                        loop = false;

                    }

                }
                return number;

            }
            while (loop);


        }

        public bool ProceedTransaction(int id)
        {
            int result = 0;

            try
            {
                using (var db = new BankingContext())
                {
                    DbSet<TransactionDetail> alldetails = db.TransactionDetails;
                    var matchingTrans = alldetails.Where(p => p.TransactionReferenceId == id);
                    if (matchingTrans != null && matchingTrans.Count() > 0)
                    {
                        TransactionDetail a = matchingTrans.First<TransactionDetail>();



                        var custId = a.CustomerId;
                        var toID = a.PayeeId;


                        DbSet<AccountFields> allaccfield = db.AccountFields;
                        var accCred = allaccfield.Where(p => p.CustomerId == custId);
                        if (accCred != null && accCred.Count() > 0)
                        {




                            AccountFields fromcustAcc = accCred.First<AccountFields>();

                            DbSet<BankCredential> allCred = db.BankCredentials;
                            var fromcustCredid = fromcustAcc.CredentialId;
                            var Toacc = allaccfield.Where(p => p.CustomerId == toID);
                            if (Toacc != null && Toacc.Count() > 0)
                            {




                                AccountFields ToaccCred = Toacc.First<AccountFields>();



                                var tocustCredid = ToaccCred.CredentialId;

                                var fromaccCredential = allCred.Where(p => p.CredentialId == fromcustCredid);
                                var ToaccCredential = allCred.Where(p => p.CredentialId == tocustCredid);
                                if (fromaccCredential != null && fromaccCredential.Count() > 0 && ToaccCredential != null
                                    && ToaccCredential.Count() > 0)
                                {

                                    BankCredential fromcustAccCred = fromaccCredential.First<BankCredential>();
                                    BankCredential tocustAccCred = ToaccCredential.First<BankCredential>();
                                    fromcustAccCred.AccountBalance -= a.Transactionamount;
                                    tocustAccCred.AccountBalance += a.Transactionamount;
                                    a.PaymentStatus = "Done";


                                    alldetails.Update(a);
                                    result = db.SaveChanges();

                                }

                            }
                            else
                            {
                                var fromaccCredential = allCred.Where(p => p.CredentialId == fromcustCredid);

                                BankCredential fromcustAccCred = fromaccCredential.First<BankCredential>();

                                fromcustAccCred.AccountBalance -= a.Transactionamount;
                                a.PaymentStatus = "Done";
                                alldetails.Update(a);
                                result = db.SaveChanges();







                            }

                        }

                    }

                }
                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        TransactionModel ITransactionDaoImpl.FetchAccountBystatus(string status, int id)
        {
            throw new NotImplementedException();
        }
    }
}
