using Microsoft.EntityFrameworkCore;
using TyTManagmentSystem.Models;

namespace TyTManagmentSystem.DataAccess
{
  public class TyTContext : DbContext
  {
    public TyTContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Price> Prices { get; set; }
    public DbSet<Inventory> Inventorys { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
  }
}
