using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class PayeeDetail
{
    public int PayeeId { get; set; }

    public string? PayeeName { get; set; }

    public long? PayeeAccountNumber { get; set; }

    public string? NickName { get; set; }

    public int? CustomerId { get; set; }

    public long? PayeeMobileNumber { get; set; }

    public virtual AccountFields? Customer { get; set; }

    public virtual ICollection<TransactionDetail> TransactionDetails { get; set; } = new List<TransactionDetail>();
}
