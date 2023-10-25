using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels
{
    public class ForgetCredentials
    {
        public long? AccountNumber { get; set; }

        public string otp { get; set; }

        public int? UserId { get; set; }

        public string NetBankingPassword { get; set; }
        public string OldNetBankingPassword { get; set; }

        public string TransactionPassword { get; set; }

    }
}
