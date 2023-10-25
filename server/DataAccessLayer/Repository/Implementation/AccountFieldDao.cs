
using DataAccessLayer.Models;
using DataAccessLayer.Repository.Implementation;
using Microsoft.EntityFrameworkCore;
using Server.BusinessModels;
using System.Net.Mail;
using System.Text;

namespace DataAccessLayer.Repository.Abstraction

{
    public class AccountFieldDao : IAccountFieldDao
    {
        public List<AccountModel> FetchAllAccount()
        {
            List<AccountModel> businessDetails = null;
            try
            {
                using (var db = new BankingContext())
                {
                    DbSet<AccountFields> allAcc = db.AccountFields;
                    if (allAcc.Count() > 0)
                    {
                        businessDetails =
                            allAcc
                             .Select(
                                (AccountFields a) =>
                                     new AccountModel
                                     {
                                         CustomerId = a.CustomerId,
                                         Title = a.Title,
                                         FirstName = a.FirstName,
                                         LastName = a.LastName,
                                         Mobileno = a.Mobileno,
                                         MiddleName = a.MiddleName,
                                         EmailId = a.EmailId,
                                         AadhaarCardNumber = a.AadhaarCardNumber,
                                         Dob = a.Dob,

                                         ResidentialAddressLine1 = a.ResidentialAddressLine1,
                                         ResidentialAddressLine2 = a.ResidentialAddressLine2,
                                         ResidentialCity = a.ResidentialCity,
                                         ResidentialLandmark = a.ResidentialLandmark,
                                         ResidentialPincode = a.ResidentialPincode,
                                         ResidentialState = a.ResidentialState,
                                         PermanentAddressLine1 = a.PermanentAddressLine1,
                                         PermanentAddressLine2 = a.PermanentAddressLine2,
                                         PermanentCity = a.PermanentCity,
                                         PermanentLandmark = a.PermanentLandmark,
                                         PermanentPincode = a.PermanentPincode,
                                         PermanentState = a.PermanentState,
                                         CredentialId = a.CredentialId,
                                         Occupationdetails = a.Occupationdetails,
                                         OccupationType = a.OccupationType,
                                         Sourceofincome = a.Sourceofincome,
                                         GrossAnnualIncome = a.GrossAnnualIncome,

                                         Status = a.Status,




                                     }
                             )
                             .ToList<AccountModel>();

                    }
                }
                return businessDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public AccountModel FetchAccountById(int id)
        {
            AccountModel businessDetails = null;

            try
            {
                using (var db = new BankingContext())
                {
                    DbSet<AccountFields> alldetails = db.AccountFields;
                    var matchingAccount = alldetails.Where(p => p.CustomerId == id);


                    if (matchingAccount != null && matchingAccount.Count() > 0)
                    {


                        AccountFields a = matchingAccount.First<AccountFields>();

                        businessDetails = new AccountModel
                        {
                            CustomerId = a.CustomerId,
                            Title = a.Title,
                            FirstName = a.FirstName,
                            LastName = a.LastName,
                            Mobileno = a.Mobileno,
                            MiddleName = a.MiddleName,
                            EmailId = a.EmailId,
                            AadhaarCardNumber = a.AadhaarCardNumber,
                            Dob = a.Dob,

                            ResidentialAddressLine1 = a.ResidentialAddressLine1,
                            ResidentialAddressLine2 = a.ResidentialAddressLine2,
                            ResidentialCity = a.ResidentialCity,
                            ResidentialLandmark = a.ResidentialLandmark,
                            ResidentialPincode = a.ResidentialPincode,
                            ResidentialState = a.ResidentialState,
                            PermanentAddressLine1 = a.PermanentAddressLine1,
                            PermanentAddressLine2 = a.PermanentAddressLine2,
                            PermanentCity = a.PermanentCity,
                            PermanentLandmark = a.PermanentLandmark,
                            PermanentPincode = a.PermanentPincode,
                            PermanentState = a.PermanentState,
                            CredentialId = a.CredentialId,
                            Occupationdetails = a.Occupationdetails,
                            OccupationType = a.OccupationType,
                            Sourceofincome = a.Sourceofincome,
                            GrossAnnualIncome = a.GrossAnnualIncome,

                            Status = a.Status,



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

        public List<AccountModel> FetchAccountByStatus(string status)
        {
            List<AccountModel> businessDetails = null;

            try
            {
                using (var db = new BankingContext())
                {
                    DbSet<AccountFields> allAcc = db.AccountFields;
                    var matchingAccount = allAcc.Where(p => p.Status == status);


                    if (matchingAccount != null && matchingAccount.Count() > 0)
                    {

                        businessDetails =
                          matchingAccount
                           .Select(
                              (AccountFields a) =>
                                   new AccountModel
                                   {
                                       CustomerId = a.CustomerId,
                                       Title = a.Title,
                                       FirstName = a.FirstName,
                                       LastName = a.LastName,
                                       Mobileno = a.Mobileno,
                                       MiddleName = a.MiddleName,
                                       EmailId = a.EmailId,
                                       AadhaarCardNumber = a.AadhaarCardNumber,
                                       Dob = a.Dob,

                                       ResidentialAddressLine1 = a.ResidentialAddressLine1,
                                       ResidentialAddressLine2 = a.ResidentialAddressLine2,
                                       ResidentialCity = a.ResidentialCity,
                                       ResidentialLandmark = a.ResidentialLandmark,
                                       ResidentialPincode = a.ResidentialPincode,
                                       ResidentialState = a.ResidentialState,
                                       PermanentAddressLine1 = a.PermanentAddressLine1,
                                       PermanentAddressLine2 = a.PermanentAddressLine2,
                                       PermanentCity = a.PermanentCity,
                                       PermanentLandmark = a.PermanentLandmark,
                                       PermanentPincode = a.PermanentPincode,
                                       PermanentState = a.PermanentState,
                                       CredentialId = a.CredentialId,
                                       Occupationdetails = a.Occupationdetails,
                                       OccupationType = a.OccupationType,
                                       Sourceofincome = a.Sourceofincome,
                                       GrossAnnualIncome = a.GrossAnnualIncome,

                                       Status = a.Status,




                                   }
                           )
                           .ToList<AccountModel>();

                    }
                }
                return businessDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool InsertAccountField(AccountModel p)
        {
            int result = 0;
            try
            {
                using (var db = new BankingContext())
                {
                    DbSet<AccountFields> allAccount = db.AccountFields;
                    AccountFields entityModelObject = new AccountFields
                    {
                        Title = p.Title,
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        Mobileno = p.Mobileno,
                        MiddleName = p.MiddleName,
                        EmailId = p.EmailId,
                        AadhaarCardNumber = p.AadhaarCardNumber,
                        Dob = p.Dob,

                        ResidentialAddressLine1 = p.ResidentialAddressLine1,
                        ResidentialAddressLine2 = p.ResidentialAddressLine2,
                        ResidentialCity = p.ResidentialCity,
                        ResidentialLandmark = p.ResidentialLandmark,
                        ResidentialPincode = p.ResidentialPincode,
                        ResidentialState = p.ResidentialState,
                        PermanentAddressLine1 = p.PermanentAddressLine1,
                        PermanentAddressLine2 = p.PermanentAddressLine2,
                        PermanentCity = p.PermanentCity,
                        PermanentLandmark = p.PermanentLandmark,
                        PermanentPincode = p.PermanentPincode,
                        PermanentState = p.PermanentState,

                        Occupationdetails = p.Occupationdetails,
                        OccupationType = p.OccupationType,
                        Sourceofincome = p.Sourceofincome,
                        GrossAnnualIncome = p.GrossAnnualIncome,

                        Status = "Requested"

                    };
                    SendMail(p.EmailId);

                    allAccount.Add(entityModelObject);
                    result = db.SaveChanges();
                }
                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UpdateAccountField(AccountModel p, int id)
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

                        AccountFields a = matchingAccount.First<AccountFields>();

                        a.FirstName = p.FirstName;
                        a.LastName = p.LastName;
                        a.AadhaarCardNumber = p.AadhaarCardNumber;
                        a.Dob = p.Dob;
                        a.EmailId = p.EmailId;
                        a.GrossAnnualIncome = p.GrossAnnualIncome;
                        a.Status = p.Status;
                        a.MiddleName = p.MiddleName;
                        a.Mobileno = p.Mobileno;
                        a.Occupationdetails = p.Occupationdetails;
                        a.OccupationType = p.OccupationType;
                        a.ResidentialAddressLine1 = p.ResidentialAddressLine1;
                        a.ResidentialAddressLine2 = p.ResidentialAddressLine2;
                        a.PermanentAddressLine1 = p.PermanentAddressLine1;
                        a.PermanentAddressLine2 = p.PermanentAddressLine2;
                        a.PermanentCity = p.PermanentCity;
                        a.PermanentLandmark = p.PermanentLandmark;
                        a.PermanentPincode = p.PermanentPincode;
                        a.ResidentialCity = p.ResidentialCity;
                        a.ResidentialLandmark = p.ResidentialLandmark;
                        a.PermanentState = p.PermanentState;
                        a.ResidentialPincode = p.ResidentialPincode;
                        a.ResidentialState = p.ResidentialState;
                        a.ResidentialCity = p.ResidentialCity;
                        a.Sourceofincome = p.Sourceofincome;

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
        public bool DeleteAccountFieldbyID(int id)
        {
            int res = 0;
            try
            {
                using (var db = new BankingContext())
                {
                    DbSet<AccountFields> alldetails = db.AccountFields;
                    var matchingAccount = alldetails.Where(p => p.CustomerId == id);
                    if (matchingAccount != null && matchingAccount.Count() > 0)
                    {
                        AccountFields p = matchingAccount.First<AccountFields>();
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





        public void SendMail(string to)
        {


            //To address    
            string from = "dotnetbanking@gmail.com"; //From address    
            MailMessage message = new MailMessage(from, to);
            string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

            //string otp = GenerateRandomOTP(8, saAllowedCharacters);
            string mailbody = $"Submitted succesfully ";
            message.Subject = "Create Account form Submitted";
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

        public void SendMailforOtp(string to)
        {


            //To address    
            string from = "dotnetbanking@gmail.com"; //From address    
            MailMessage message = new MailMessage(from, to);
            string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

            string otp = GenerateRandomOTP(8, saAllowedCharacters);
            string mailbody = $"Your otp is {otp} ";
            message.Subject = "Create Account form Submitted";
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
