using System;
using System.Collections.Generic;

namespace Repository;

public partial class ModeOfTransaction
{
    public int ModeId { get; set; }

    public int Modes { get; set; }

    public virtual ICollection<TransactionDetail> TransactionDetails { get; set; } = new List<TransactionDetail>();
}
