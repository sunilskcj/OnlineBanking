using System;
namespace server.BusinessModels
{
	public class TransactionDetails
    {
        public string RecipientAccountNumber { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public decimal? Transactionamount { get; set; }
        public DateTime? TransactionDate { get; set; }
        public int ModeId { get; set; }
        public string Remark { get; set; }
        public string AccountNumber { get; set; }
        public string TransactionReferenceId { get; set; }

       

    }
}

  
