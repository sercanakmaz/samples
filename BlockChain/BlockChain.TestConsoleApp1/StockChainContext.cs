using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlockChain.TestConsoleApp1
{
    public class StockChainContext: DbContext
    {
        public StockChainContext()
              : base(GetOptions())
        {
            this.ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public static DbContextOptions<StockChainContext> GetOptions()
        {
            DbContextOptionsBuilder<StockChainContext> optionsBuilder = new DbContextOptionsBuilder<StockChainContext>();

            //var configuration = IocManager.Resolve<IConfigurationRoot>();

            //optionsBuilder.UseNpgsql(configuration.GetConnectionString("StockChainDatabase"));
            optionsBuilder.UseNpgsql("User ID=postgres;Password=1;Host=localhost;Port=5432;Database=stockchain;Pooling=true");

            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            return optionsBuilder.Options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Transaction>()
                .ToTable("transaction");

            modelBuilder.Entity<Transaction>()
                .Property(p=>p.Id)
                .HasColumnName(nameof(Transaction.Id).ToLowerInvariant());

            modelBuilder.Entity<Transaction>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Transaction>()
                .Property(p => p.PublicKey)
                .HasMaxLength(256)
                .HasColumnName(nameof(Transaction.PublicKey).ToLowerInvariant());
            modelBuilder.Entity<Transaction>()
                .Property(p => p.Timestamp)
                .HasColumnName(nameof(Transaction.Timestamp).ToLowerInvariant());
            modelBuilder.Entity<Transaction>()
                .Property(p => p.Data)
                .HasColumnName(nameof(Transaction.Data).ToLowerInvariant());
        }
    }
}
