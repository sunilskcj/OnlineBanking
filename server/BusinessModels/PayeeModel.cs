using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels
{
    public class PayeeModel
    {
        public PayeeModel()
        {
            TransactionDetails = new HashSet<TransactionModel>();
        }

        public int PayeeId { get; set; }
        public string PayeeName { get; set; }
        public long? PayeeAccountNumber { get; set; }
        public string NickName { get; set; }
        public long? PayeeMobileNumber { get; set; }
        public int? CustomerId { get; set; }

        public virtual ICollection<TransactionModel> TransactionDetails { get; set; }
    }
}
