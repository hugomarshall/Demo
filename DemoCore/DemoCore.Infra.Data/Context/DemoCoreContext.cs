using System.IO;
using DemoCore.Domain.Models;
using DemoCore.Infra.Data.EntityConfigs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DemoCore.Infra.Data.Context
{
    public class DemoCoreContext: DbContext
    {
        DbSet<People> People { get; set; }
        DbSet<Occupation> Occupation { get; set; }
        DbSet<BestWorkTime> BestWorkTime { get; set; }
        DbSet<WorkAvailability> WorkAvailability { get; set; }
        DbSet<OccupationBestWorkTime> OccupationBestWorkTime { get; set; }
        DbSet<OccupationWorkAvailability> OccupationWorkAvailability { get; set; }
        DbSet<Knowledge> Knowledge { get; set; }
        DbSet<Designer> Designer { get; set; }
        DbSet<Developer> Developer { get; set; }
        DbSet<KnowledgeDesigner> KnowledgeDesigner { get; set; }
        DbSet<KnowledgeDeveloper> KnowledgeDeveloper { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PeopleConfiguration());
            modelBuilder.ApplyConfiguration(new KnowledgeConfiguration());
            modelBuilder.ApplyConfiguration(new OccupationConfiguration());


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
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
