using System;
using System.Collections.Generic;

namespace Repository;

public partial class BankCredential
{
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

    public string? TransactionPassword { get; set; }

    public string? NetBankingPassword { get; set; }

    public virtual ICollection<AccountsField> AccountFields { get; set; } = new List<AccountsField>();
}
