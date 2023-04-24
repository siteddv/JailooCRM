using Microsoft.EntityFrameworkCore;

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
        }
    }
}
