using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public partial class BankingContext : DbContext
{
    public BankingContext()
    {
    }

    public BankingContext(DbContextOptions<BankingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccountsField> AccountFields { get; set; }

    public virtual DbSet<AdminDetail> AdminDetails { get; set; }

    public virtual DbSet<BankCredential> BankCredentials { get; set; }

    public virtual DbSet<ModeOfTransaction> ModeOfTransactions { get; set; }

    public virtual DbSet<PayeeDetail> PayeeDetails { get; set; }

    public virtual DbSet<TransactionDetail> TransactionDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SKCJPC;Initial Catalog=Banking;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountsField>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__AccountF__A4AE64B899050B2D");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.CredentialId).HasColumnName("CredentialID");
            entity.Property(e => e.Dob)
                .HasColumnType("date")
                .HasColumnName("DOB");
            entity.Property(e => e.EmailId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("emailID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.GrossAnnualIncome).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MiddleName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.OccupationType)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.Occupationdetails)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.PermanentAddressLine1)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.PermanentAddressLine2)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.PermanentCity)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.PermanentLandmark)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.PermanentState)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.ResidentialAddressLine1)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.ResidentialAddressLine2)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.ResidentialCity)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.ResidentialLandmark)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.ResidentialState)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.Sourceofincome)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(5)
                .IsUnicode(false);

            entity.HasOne(d => d.Credential).WithMany(p => p.AccountFields)
                .HasForeignKey(d => d.CredentialId)
                .HasConstraintName("fkey_credID");
        });

        modelBuilder.Entity<AdminDetail>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__AdminDet__719FE4E8AD081DFB");

            entity.Property(e => e.AdminId)
                .ValueGeneratedNever()
                .HasColumnName("AdminID");
            entity.Property(e => e.AdminPassword)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BankCredential>(entity =>
        {
            entity.HasKey(e => e.CredentialId).HasName("PK__BankCred__2C58F9EC971AE52C");

            entity.Property(e => e.CredentialId).HasColumnName("CredentialID");
            entity.Property(e => e.AccountBalance).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreditCardExpiry).HasColumnType("date");
            entity.Property(e => e.DebitCardExpiry).HasColumnType("date");
            entity.Property(e => e.NetBankingPassword)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.TransactionPassword)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<ModeOfTransaction>(entity =>
        {
            entity.HasKey(e => e.ModeId).HasName("PK__ModeOfTr__D83F75E4075C1575");

            entity.ToTable("ModeOfTransaction");

            entity.Property(e => e.ModeId)
                .ValueGeneratedNever()
                .HasColumnName("ModeID");
        });

        modelBuilder.Entity<PayeeDetail>(entity =>
        {
            entity.HasKey(e => e.PayeeId).HasName("PK__PayeeDet__0BC3E43902DBF44A");

            entity.Property(e => e.PayeeId).HasColumnName("PayeeID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.NickName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PayeeName)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.Customer).WithMany(p => p.PayeeDetails)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("fkey_CusID");
        });

        modelBuilder.Entity<TransactionDetail>(entity =>
        {
            entity.HasKey(e => e.RefId).HasName("PK__Transact__2D2A2CF165959D99");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.MaturityInstruction)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.ModeId).HasColumnName("ModeID");
            entity.Property(e => e.PayeeId).HasColumnName("PayeeID");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Remark)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.TransactionDate).HasColumnType("datetime");
            entity.Property(e => e.Transactionamount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Customer).WithMany(p => p.TransactionDetails)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Transacti__Custo__2BFE89A6");

            entity.HasOne(d => d.Mode).WithMany(p => p.TransactionDetails)
                .HasForeignKey(d => d.ModeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkey_modeID");

            entity.HasOne(d => d.Payee).WithMany(p => p.TransactionDetails)
                .HasForeignKey(d => d.PayeeId)
                .HasConstraintName("fkey_payeeID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
