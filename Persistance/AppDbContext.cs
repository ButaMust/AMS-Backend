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
    }
}