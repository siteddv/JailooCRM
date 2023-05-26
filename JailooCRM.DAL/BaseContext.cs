using JailooCRM.DAL.Common;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace JailooCRM.DAL
{
    public abstract class BaseContext : DbContext
    {
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Chief> Chiefs { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientPlace> ClientPlaces { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<LoyalityItem> LoyalityItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<PersonBankAccount> PersonBankAccounts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Waiter> Waiters { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PersonBankAccount>()
                .HasOne(ba => ba.Person)
                .WithMany(a => a.PersonBankAccounts)
                .HasForeignKey(ba => ba.PersonId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PersonBankAccount>()
                .HasOne(ba => ba.BankAccount)
                .WithMany(b => b.PersonBankAccounts)
                .HasForeignKey(ba => ba.BankAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Client>()
                .HasOne(e => e.LoyalityItem)
                .WithOne(e => e.Client)
                .HasForeignKey<LoyalityItem>(e => e.ClientId)
                .IsRequired();

            modelBuilder.Entity<PersonBankAccount>()
                .HasKey(pba => new { pba.PersonId, pba.BankAccountId });

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Waiter)
                .WithMany(w => w.Orders)
                .HasForeignKey(o => o.WaiterId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Waiter>()
                .HasMany(w => w.Orders)
                .WithOne(o => o.Waiter)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Subcategories)
                .WithOne(o => o.Department)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
