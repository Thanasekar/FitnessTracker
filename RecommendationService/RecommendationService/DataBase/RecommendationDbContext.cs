using Microsoft.EntityFrameworkCore;
using RecommendationService.Models;

namespace RecommendationService.DataBase
{
    public class RecommentationDbContext : DbContext
    {
        public RecommentationDbContext(DbContextOptions<RecommentationDbContext> options) : base(options) { }

        public override int SaveChanges()
        {
            var selectedEntityList = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseModel &&
                            (x.State == EntityState.Added || x.State == EntityState.Modified));

            return base.SaveChanges();
        }

        public DbSet<RecommentationDetail> Recommendation { get; set; }
    }
}
