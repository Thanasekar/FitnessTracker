using HealthMetricsService.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthMetricsService.DataBase
{
    public class HealthMetricsDbContext : DbContext
    {
        public HealthMetricsDbContext(DbContextOptions<HealthMetricsDbContext> options) : base(options) { }

        public override int SaveChanges()
        {
            var selectedEntityList = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseModel &&
                            (x.State == EntityState.Added || x.State == EntityState.Modified));

            return base.SaveChanges();
        }

        public DbSet<HealthMetrics> HealthMetricsDetail { get; set; }
    }
}
