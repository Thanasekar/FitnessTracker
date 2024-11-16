using Microsoft.EntityFrameworkCore;
using UserService.Models;

namespace UserService.DataBase
{
    public class UserDetailDbContext : DbContext
    {
        public UserDetailDbContext(DbContextOptions<UserDetailDbContext> options) : base(options) { }

        public override int SaveChanges()
        {
            var selectedEntityList = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseModel &&
                            (x.State == EntityState.Added || x.State == EntityState.Modified));

            return base.SaveChanges();
        }

        public DbSet<UserDetail> UserDetail { get; set; }
    }
}
