namespace WebSignalr.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.AccountID)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Account_Email)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Account_Pass)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Account_IDAPI)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Account_Code)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Account_TokenApi)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Account_oauth_provider)
                .IsUnicode(false);
        }
    }
}
