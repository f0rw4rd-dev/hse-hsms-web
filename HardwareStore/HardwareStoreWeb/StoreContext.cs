using HardwareStoreWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace HardwareStoreWeb
{
    public readonly struct DbData
    {
        public static readonly string Database = "hardware_store_ms";
        public static readonly string Username = "postgres";
        public static readonly string Password = "root";
        public static readonly string Host = "localhost";
        public static readonly string Port = "5433";
    }

    public class StoreContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<ComponentDetail> ComponentDetails { get; set; }
        public DbSet<ComponentStorage> ComponentStorages { get; set; }
        public DbSet<ComponentType> ComponentTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderComponent> OrderComponents { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<DetailType> DetailTypes { get; set; }

        public StoreContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql($"Host={DbData.Host};Port={DbData.Port};Database={DbData.Database};Username={DbData.Username};Password={DbData.Password}");
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
