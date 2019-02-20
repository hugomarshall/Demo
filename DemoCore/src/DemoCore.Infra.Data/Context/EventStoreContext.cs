using DemoCore.Domain.Core.Events;
using DemoCore.Infra.Data.EntityConfigs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DemoCore.Infra.Data.Context
{
    public class EventStoreContext: DbContext
    {
        public DbSet<StoredEvent> StoredEvent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("EventStore");
            modelBuilder.ApplyConfiguration(new StoredEventConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"), options =>
            {
                options.MigrationsHistoryTable("__EventSourceMigrationsHistory", "EventStore");
            });
        }
    }
}
