using Domain;
using Microsoft.EntityFrameworkCore;


// public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
// {
//     public required DbSet<User> Users { get; set; }
// }

namespace App.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Building> Buildings { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateTimestamps()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is BaseEntity && 
                        (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var now = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                    ((BaseEntity)entry.Entity).CreatedAt = now;

                ((BaseEntity)entry.Entity).UpdatedAt = now;
            }
        }
    }
}