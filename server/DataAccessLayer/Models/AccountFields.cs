using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class AccountFields
{
    public int CustomerId { get; set; }

    public string Title { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public long Mobileno { get; set; }

    public string EmailId { get; set; } = null!;

    public long AadhaarCardNumber { get; set; }

    public DateTime Dob { get; set; }

    public string? ResidentialAddressLine1 { get; set; }

    public string? ResidentialAddressLine2 { get; set; }

    public string? ResidentialLandmark { get; set; }

    public string ResidentialState { get; set; } = null!;

    public string ResidentialCity { get; set; } = null!;

    public int ResidentialPincode { get; set; }

    public string? PermanentAddressLine1 { get; set; }

    public string? PermanentAddressLine2 { get; set; }

    public string? PermanentLandmark { get; set; }

    public string PermanentState { get; set; } = null!;

    public string PermanentCity { get; set; } = null!;

    public int PermanentPincode { get; set; }

    public string? Occupationdetails { get; set; }

    public string? OccupationType { get; set; }

    public string? Sourceofincome { get; set; }

    public decimal? GrossAnnualIncome { get; set; }

    public string? Status { get; set; }

    public int? CredentialId { get; set; }

    public virtual BankCredential? Credential { get; set; }

    public virtual ICollection<PayeeDetail> PayeeDetails { get; set; } = new List<PayeeDetail>();

    public virtual ICollection<TransactionDetail> TransactionDetails { get; set; } = new List<TransactionDetail>();
}
