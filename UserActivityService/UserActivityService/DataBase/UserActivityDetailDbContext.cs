using Microsoft.EntityFrameworkCore;
using UserActivityService.Models;

namespace UserActivityService.DataBase
{
    public class UserActivityDetailDbContext : DbContext
    {
        public UserActivityDetailDbContext(DbContextOptions<UserActivityDetailDbContext> options) : base(options) { }

        public override int SaveChanges()
        {
            var selectedEntityList = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseModel &&
                            (x.State == EntityState.Added || x.State == EntityState.Modified));

            return base.SaveChanges();
        }

        public DbSet<UserActivityDetail> UserActivityDetail { get; set; }
    }
}
