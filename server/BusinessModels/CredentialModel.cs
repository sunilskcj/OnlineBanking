using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels
{
    public class CredentialModel
    {
        public string otp { get; set; }
        public int CredentialId { get; set; }
        public int? UserId { get; set; }
        public long? AccountNumber { get; set; }
        public decimal? AccountBalance { get; set; }
        public long? DebitCardNumber { get; set; }
        public DateTime? DebitCardExpiry { get; set; }
        public int? DebitCardCvv { get; set; }
        public int? DebitCardPin { get; set; }
        public long? CreditCardNumber { get; set; }
        public DateTime? CreditCardExpiry { get; set; }
        public int? CreditCardCvv { get; set; }
        public int? CreditCardPin { get; set; }
        public string TransactionPassword { get; set; }
        public string NetBankingPassword { get; set; }




    }
}
