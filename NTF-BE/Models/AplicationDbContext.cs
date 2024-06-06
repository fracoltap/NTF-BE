using Microsoft.EntityFrameworkCore;

namespace NTF_BE.Models
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Farm> Farms { get; set; }
        public DbSet<Crop> Crops { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<FarmProduction> FarmProductions { get; set; }
    }
}
