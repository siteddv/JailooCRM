﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace JailooCRM.DAL
{
    public class PgContext : BaseContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetConnectionString("PgDbContextConnection")
                ?? throw new InvalidOperationException(
                    "Connection string 'PgDbContextConnection' not found.");

            optionsBuilder.UseNpgsql(connectionString, builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            });
        }
    }
}
