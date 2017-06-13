using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MySQL.Data.Entity.Extensions;

namespace Demo.Database
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> options) :base(options)
        {

        }
        public DemoContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=services.dev;Uid=appuser;Pwd=app;Database=Demo;");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<BadModel> DataEventRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BadModel>().HasKey(m => m.BadId);

            // shadow properties
            builder.Entity<BadModel>().Property<DateTime>("UpdatedTimestamp");

            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            UpdateUpdatedProperty<BadModel>();

            return base.SaveChanges();
        }

        private void UpdateUpdatedProperty<T>() where T : class
        {
            var modifiedSourceInfo =
                ChangeTracker.Entries<T>()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in modifiedSourceInfo)
            {
                entry.Property("RecordUpdated").CurrentValue = DateTime.UtcNow;
            }
        }
    }
}
