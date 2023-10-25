using BusinessModels;
using DataAccessLayer.Models;
using DataAccessLayer.Repository.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Implementation
{
    public class CredentialsDaoImpl : ICredentialsDaoImpl
    {
        public List<CredentialModel> FetchAllAccountCredential()
        {
            List<CredentialModel> businessDetails = null;
            try
            {
                using (var db = new BankingContext())
                {
                    DbSet<BankCredential> allAcc = db.BankCredentials;
                    if (allAcc.Count() > 0)
                    {
                        businessDetails =
                            allAcc
                             .Select(
                                (BankCredential a) =>
                                     new CredentialModel
                                     {
                                         AccountBalance = a.AccountBalance,
                                         AccountNumber = a.AccountNumber,
                                         UserId = a.UserId,
                                         NetBankingPassword = a.NetBankingPassword,
                                         TransactionPassword = a.TransactionPassword,
                                         DebitCardCvv = a.DebitCardCvv,
                                         DebitCardExpiry = a.DebitCardExpiry,
                                         DebitCardNumber = a.DebitCardNumber,
                                         DebitCardPin = a.DebitCardPin,
                                         CreditCardCvv = a.CreditCardCvv,
                                         CreditCardExpiry = a.CreditCardExpiry,
                                         CreditCardNumber = a.CreditCardNumber,
                                         CreditCardPin = a.CreditCardPin,
                                         CredentialId = a.CredentialId

                                     }
                             )
                             .ToList<CredentialModel>();

                    }
                }
                return businessDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CredentialModel FetchAccountById(int id)
        {
            CredentialModel businessDetails = null;
            try
            {
                using (var db = new BankingContext())
                {
                    DbSet<BankCredential> alldetails = db.BankCredentials;
                    var matchingAccount = alldetails.Where(p => p.AccountField.Any(a => a.CustomerId == id));
                    if (matchingAccount != null && matchingAccount.Count() > 0)
                    {


                        BankCredential a = matchingAccount.First<BankCredential>();
                        businessDetails = new CredentialModel
                        {
                            AccountBalance = a.AccountBalance,
                            AccountNumber = a.AccountNumber,
                            UserId = a.UserId,
                            NetBankingPassword = a.NetBankingPassword,
                            TransactionPassword = a.TransactionPassword,
                            DebitCardCvv = a.DebitCardCvv,
                            DebitCardExpiry = a.DebitCardExpiry,
                            DebitCardNumber = a.DebitCardNumber,
                            DebitCardPin = a.DebitCardPin,
                            CreditCardCvv = a.CreditCardCvv,
                            CreditCardExpiry = a.CreditCardExpiry,
                            CreditCardNumber = a.CreditCardNumber,
                            CreditCardPin = a.CreditCardPin,

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


        public bool InsertAccountCredential(int id)
        {
            int result = 0;
            try
            {
                using (var db = new BankingContext())
                {
                    DbSet<BankCredential> allAccountCred = db.BankCredentials;

                    DbSet<AccountFields> alldetails = db.AccountFields;
                    var matchingAccount = alldetails.Where(p => p.CustomerId == id);
                    if (matchingAccount != null && matchingAccount.Count() > 0)
                    {
                        AccountFields p = matchingAccount.First<AccountFields>();
                        BankCredential bk = new BankCredential
                        {
                            TransactionPassword = PasswordGenerator(13),
                            NetBankingPassword = PasswordGenerator(13),
                            DebitCardPin = PinGenerator(),
                            DebitCardCvv = Cvvgenerator(),
                            CreditCardExpiry = PredictExpiry(),
                            DebitCardExpiry = PredictExpiry(),
                            DebitCardNumber = DebitCardNumberGenerator(),
                            CreditCardPin = PinGenerator(),
                            CreditCardCvv = Cvvgenerator(),
                            CreditCardNumber = CreditCardNumberGenerator(),
                            AccountNumber = AccNumberGenerator(),
                            AccountBalance = 0


                        };
                        SendMailforCred(p.EmailId, bk, id);
                        allAccountCred.Add(bk);

                        p.Credential = bk;
                        p.Status = "Active";

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
        public bool UpdateAccountCredential(CredentialModel p, int id)
        {

            int result = 0;
            try
            {
                using (var db = new BankingContext())
                {
                    DbSet<BankCredential> alldetails = db.BankCredentials;
                    var matchingAccount = alldetails.Where(p => p.CredentialId == id);
                    if (matchingAccount != null && matchingAccount.Count() > 0)
                    {

                        BankCredential a = matchingAccount.First<BankCredential>();

                        a.UserId = p.UserId;
                        a.NetBankingPassword = p.NetBankingPassword;
                        a.TransactionPassword = p.TransactionPassword;



                        alldetails.Update(a);
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



        public bool DeleteAccountCredential(int id)
        {
            int res = 0;
            try
            {
                using (var db = new BankingContext())
                {
                    DbSet<BankCredential> alldetails = db.BankCredentials;
                    var matchingAccount = alldetails.Where(p => p.CredentialId == id);
                    if (matchingAccount != null && matchingAccount.Count() > 0)
                    {
                        BankCredential p = matchingAccount.First<BankCredential>();
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

        public bool UpdateAccountFieldforNetBanking(CredentialModel cred, int id)
        {

            int result = 0;
            try
            {
                using (var db = new BankingContext())
                {
                    DbSet<AccountFields> alldetails = db.AccountFields;
                    var matchingAccount = alldetails.Where(p => p.CustomerId == id);
                    if (matchingAccount != null && matchingAccount.Count() > 0)
                    {
                        AccountFields ac = matchingAccount.First<AccountFields>();
                        DbSet<BankCredential> allcreddetails = db.BankCredentials;

                        var matchingAccountcred = allcreddetails.Where(p => p.AccountNumber == cred.AccountNumber && p.NetBankingPassword == cred.NetBankingPassword && p.TransactionPassword == cred.TransactionPassword);
                        if (matchingAccountcred != null && matchingAccountcred.Count() > 0)
                        {
                            BankCredential credential = matchingAccountcred.First<BankCredential>();
                            string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
                            string otp = GenerateRandomOTP(4, saAllowedCharacters);
                            SendMailforOtp(ac.EmailId, otp);
                            if (otp == cred.otp)
                            {
                                allcreddetails.Update(credential);
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


        private static Random random = new Random();

        private string PasswordGenerator(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private static Random rnd = new Random(16);
        private long AccNumberGenerator()
        {
            bool loop = true;

            do
            {
                long number = rnd.Next();
                using (var db = new BankingContext())
                {

                    DbSet<BankCredential> alldetails = db.BankCredentials;
                    var matchingAccount = alldetails.Where(p => p.AccountNumber == number);
                    if (matchingAccount == null)
                    {
                        loop = false;

                    }

                }
                return number;

            }
            while (loop);

        }

        private long CreditCardNumberGenerator()
        {
            bool loop = true;

            do
            {
                long number = rnd.Next();
                using (var db = new BankingContext())
                {

                    DbSet<BankCredential> alldetails = db.BankCredentials;
                    var matchingAccount = alldetails.Where(p => p.CreditCardNumber == number);
                    if (matchingAccount == null)
                    {
                        loop = false;

                    }

                }
                return number;

            }
            while (loop);

        }
        private long DebitCardNumberGenerator()
        {
            bool loop = true;

            do
            {
                long number = rnd.Next();
                using (var db = new BankingContext())
                {

                    DbSet<BankCredential> alldetails = db.BankCredentials;
                    var matchingAccount = alldetails.Where(p => p.DebitCardNumber == number);
                    if (matchingAccount == null)
                    {
                        loop = false;

                    }

                }
                return number;

            }
            while (loop);

        }

        private static Random randomcvv = new Random(3);
        private int Cvvgenerator()
        {
            return randomcvv.Next();
        }
        private static Random randompin = new Random(4);
        private int PinGenerator()
        {
            return randompin.Next();
        }

        private DateTime PredictExpiry()
        {
            DateTime now = DateTime.Now;
            DateTime expiryYear = now.AddYears(5);
            return expiryYear;
        }


        public void SendMailforOtp(string to, string otp)
        {


            //To address    
            string from = "dotnetbanking@gmail.com"; //From address    
            MailMessage message = new MailMessage(from, to);
            string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

            //string otp = GenerateRandomOTP(8, saAllowedCharacters);
            string mailbody = $"Your Application is verifed." +
                $"Your Credentials are..." +
                $"Credential Id:" +
                $"CustomerID:" +
                $"LoginPassword:" +
                $"Transaction Password:" +
                $"Kindly ensure to keep the credentials safely.Do not disclose it at any Cause";
            message.Subject = "Credentials for your Account";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("dotnetbanking@gmail.com", "C#sqlAngular07");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void SendMailforCred(string to, BankCredential bk, int id)
        {



            string from = "dotnetbanking@gmail.com"; //From address    
            MailMessage message = new MailMessage(from, to);

            string mailbody = $"Your Application for Account Creation is verified is verifed." +
                $"Your Credentials are..." +
                $"Customer ID : {id}" +
                $"LoginPassword: {bk.NetBankingPassword}" +

                $"Transaction Password: {bk.TransactionPassword}" +
                $"Kindly ensure to keep the credentials safely.Do not disclose it at any Cause";
            message.Subject = "Credentials for your Account";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("dotnetbanking@gmail.com", "C#sqlAngular07");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static public string GenerateRandomOTP(int iOTPLength, string[] saAllowedCharacters)

        {

            string sOTP = String.Empty;

            string sTempChars = String.Empty;

            Random rand = new Random();

            for (int i = 0; i < iOTPLength; i++)

            {

                int p = rand.Next(0, saAllowedCharacters.Length);

                sTempChars = saAllowedCharacters[rand.Next(0, saAllowedCharacters.Length)];

                sOTP += sTempChars;

            }

            return sOTP;

        }

    }
}
