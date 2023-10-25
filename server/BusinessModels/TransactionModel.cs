using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels
{
    public class TransactionModel
    {

        public DateTime? TransactionDate { get; set; }
        public int ModeId { get; set; }
        public string Remark { get; set; }
        public decimal Transactionamount { get; set; }
        public int? TransactionReferenceId { get; set; }
        public int? CustomerId { get; set; }
        public int? PayeeId { get; set; }
        public long? AccountNumber { get; set; }
        public long? PayeeAccountNumber { get; set; }
        public string MaturityInstruction { get; set; }
        public long? MobileNumber { get; set; }
        public string PaymentStatus { get; set; }

    }
}
