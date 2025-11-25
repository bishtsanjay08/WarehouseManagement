using Microsoft.EntityFrameworkCore;
using WarehouseManagement.Models;
namespace WarehouseManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Store> Stores { get; set; }

        public DbSet<StoreHistory> StoreHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>().HasQueryFilter(x => !x.IsDeleted);
        }

    }
}