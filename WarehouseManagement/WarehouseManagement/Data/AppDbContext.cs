using Microsoft.EntityFrameworkCore;
using WarehouseManagement.Models.Entities;

namespace WarehouseManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Warehouse> Warehouses { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Inventory> Inventories { get; set; }
    }
}