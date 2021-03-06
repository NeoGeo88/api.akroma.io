using System;
using Akroma.Persistence.SQL.Model;
using Microsoft.EntityFrameworkCore;

namespace Akroma.Persistence.SQL
{
    public class AkromaContext : DbContext
    {
        public AkromaContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<TransactionEntity> Transactions { get; set; }
        public DbSet<BlockEntity> Blocks { get; set; }
        public DbSet<PriceEntity> Prices { get; set; }
        public DbSet<NetworkEntity> Network { get; set; }
        public DbSet<TransactionHistoryEntity> TransactionHistory { get; set; }
        public DbQuery<AddressToEntity> AddressTo { get; set; }
        public DbQuery<AddressFromEntity> AddressFrom { get; set; }
        public DbQuery<AddressEntity> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Query<AddressToEntity>().ToView("AddressTo");
            modelBuilder.Query<AddressFromEntity>().ToView("AddressFrom");
            modelBuilder.Query<AddressEntity>().ToView("Address");

            modelBuilder.Entity<TransactionEntity>()
                .Property(x => x.Hash)
                .HasMaxLength(200);

            modelBuilder.Entity<TransactionEntity>()
                .HasIndex(x => x.To);

            modelBuilder.Entity<TransactionEntity>()
                .HasIndex(x => x.From);

            modelBuilder.Entity<TransactionEntity>()
                .HasIndex(x => x.BlockHash);

            modelBuilder.Entity<TransactionEntity>()
                .Property(x => x.Value)
                .HasColumnType("decimal(38,18)");

            modelBuilder.Entity<BlockEntity>()
                .HasIndex(x => x.Miner);

            modelBuilder.Entity<PriceEntity>()
                .HasIndex(x => x.CreatedAt);

            modelBuilder.Entity<PriceEntity>()
                .HasIndex(x => x.Symbol);

            base.OnModelCreating(modelBuilder);
        }

    }


    public class AkromaContextFactory : IAkromaContextFactory
    {
        public AkromaContext Create()
        {
            var builder = new DbContextOptionsBuilder<AkromaContext>();
            var connection = Environment.GetEnvironmentVariable("AkromaConnectionString") ?? "";
            builder.UseSqlServer(connection, b => b.MigrationsAssembly("Akroma.Persistence.SQL"));
            return new AkromaContext(builder.Options);
        }
    }

    public interface IAkromaContextFactory
    {
        AkromaContext Create();
    }
}
