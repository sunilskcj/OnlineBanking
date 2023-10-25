using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class TransactionDetail
{
    public DateTime? TransactionDate { get; set; }

    public int ModeId { get; set; }

    public string? Remark { get; set; }

    public decimal Transactionamount { get; set; }

    public int? CustomerId { get; set; }

    public int? PayeeId { get; set; }

    public int? TransactionReferenceId { get; set; }

    public string? MaturityInstruction { get; set; }

    public int RefId { get; set; }

    public string? PaymentStatus { get; set; }

    public virtual AccountFields? Customer { get; set; }

    public virtual ModeOfTransaction Mode { get; set; } = null!;

    public virtual PayeeDetail? Payee { get; set; }
}
