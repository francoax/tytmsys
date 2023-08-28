using Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Api.Data
{
  public class TyTContext : DbContext
  {
    public TyTContext(DbContextOptions options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<ItemActualStock>().HasNoKey();
      modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
      configurationBuilder.Properties<DateTime>().HaveColumnType("datetime");
      configurationBuilder.Properties<string>().HaveMaxLength(150);
      configurationBuilder.Properties<decimal>().HavePrecision(18, 2);
    }
    public DbSet<Item> Items { get; set; }
    public DbSet<StockMovement> StockMovements { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<ItemActualStock> ItemStock { get; set; }
  }
}
