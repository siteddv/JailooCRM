using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace JailooCRM.DAL
{
    public class SqlServerContext : BaseContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetConnectionString("SqlServerDbContextConnection")
                ?? throw new InvalidOperationException(
                    "Connection string 'SqlServerDbContextConnection' not found.");

            optionsBuilder.UseSqlServer(connectionString, builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            });
        }
    }
}
