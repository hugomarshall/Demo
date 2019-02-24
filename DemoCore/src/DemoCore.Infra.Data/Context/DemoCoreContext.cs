using DemoCore.Domain.Core.Models;
using DemoCore.Domain.Models;
using DemoCore.Infra.Data.EntityConfigs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;

namespace DemoCore.Infra.Data.Context
{
    public class DemoCoreContext : DbContext
    {
        private readonly IHostingEnvironment env;

        public DemoCoreContext(IHostingEnvironment env)
        {
            this.env = env;
        }
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
            modelBuilder.HasDefaultSchema("DemoCoreData");

            modelBuilder.ApplyConfiguration(new BestWorkTimeConfiguration());
            modelBuilder.ApplyConfiguration(new DesignerConfiguration());
            modelBuilder.ApplyConfiguration(new DeveloperConfiguration());
            modelBuilder.ApplyConfiguration(new KnowledgeConfiguration());
            modelBuilder.ApplyConfiguration(new KnowledgeDesignerConfiguration());
            modelBuilder.ApplyConfiguration(new KnowledgeDeveloperConfiguration());
            modelBuilder.ApplyConfiguration(new OccupationConfiguration());
            modelBuilder.ApplyConfiguration(new OccupationBestWorkTimeConfiguration());
            modelBuilder.ApplyConfiguration(new OccupationWorkAvailabilityConfiguration());
            modelBuilder.ApplyConfiguration(new PeopleConfiguration());
            modelBuilder.ApplyConfiguration(new WorkAvailabilityConfiguration());
            

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();

            // define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"), options =>
            {
                options.MigrationsHistoryTable("__DemoCoreMigrationsHistory", "DemoCoreData");
            });
        }

        public override int SaveChanges()
        {

            var selectedEntityList = ChangeTracker.Entries()
                                .Where(x => x.Entity is Entity &&
                                (x.State == EntityState.Added || x.State == EntityState.Modified));

            //Gt user Name from  session or other authentication   
            var userName = "Test";

            foreach (var entity in selectedEntityList)
            {
                var entityBase = entity.Entity as Entity;
                if (entity.State == EntityState.Added)
                {
                    entityBase.DateCreated = DateTime.Now;
                }
                else
                {
                    base.Entry(entityBase).Property(x => x.DateCreated).IsModified = false;
                }

                entityBase.DateLastUpdate = DateTime.Now;
            }
            return base.SaveChanges();

        }

    }
}

