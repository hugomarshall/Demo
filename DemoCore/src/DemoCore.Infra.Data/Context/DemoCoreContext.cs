using System;
using DemoCore.Domain.Models;
using DemoCore.Infra.Data.EntityConfigs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DemoCore.Infra.Data.Context
{
    public class DemoCoreContext: DbContext
    {
        public DbSet<People> People { get; set; }
        public DbSet<Occupation> Occupation { get; set; }
        public DbSet<BestWorkTime> BestWorkTime { get; set; }
        public DbSet<WorkAvailability> WorkAvailability { get; set; }
        public DbSet<OccupationBestWorkTime> OccupationBestWorkTime { get; set; }
        public DbSet<OccupationWorkAvailability> OccupationWorkAvailability { get; set; }
        public DbSet<Knowledge> Knowledge { get; set; }
        public DbSet<Designer> Designer { get; set; }
        public DbSet<Developer> Developer { get; set; }
        public DbSet<KnowledgeDesigner> KnowledgeDesigner { get; set; }
        public DbSet<KnowledgeDeveloper> KnowledgeDeveloper { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BestWorkTimeConfiguration());
            modelBuilder.ApplyConfiguration(new DesignerConfiguration());
            modelBuilder.ApplyConfiguration(new DeveloperConfiguration());
            modelBuilder.ApplyConfiguration(new KnowledgeConfiguration());
            modelBuilder.ApplyConfiguration(new OccupationConfiguration());
            modelBuilder.ApplyConfiguration(new PeopleConfiguration());
            modelBuilder.ApplyConfiguration(new WorkAvailabilityConfiguration());
            

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            // define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

    }
}
