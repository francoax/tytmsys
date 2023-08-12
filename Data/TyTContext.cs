using Api.Models;
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

            modelBuilder.Entity<SuppliersItems>()
                .HasKey(si => new { si.SupplierId, si.ItemId });

            modelBuilder.Entity<Supplier>(s =>
            {
                s.OwnsOne(sup => sup.Contact);
                s.OwnsOne(sup => sup.Address);
            });

            modelBuilder.Entity<StockMovements>(sm =>
            {
                sm.HasKey(s => new { s.Id, s.ItemId });
                sm.Property(s => s.TotalPrice).HasPrecision(10, 2);
                sm.Property(s => s.Dollar_at_Date).HasPrecision(10, 2);
            });

            modelBuilder.Entity<Item>()
                .HasOne<TypeOfItem>(i => i.Type)
                .WithMany(ti => ti.Items)
                .HasForeignKey(i => i.TypeId);

            modelBuilder.Entity<Item>()
                .HasMany<StockMovements>(i => i.StockHistory)
                .WithOne(sm => sm.Item)
                .HasForeignKey(sm => sm.ItemId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StockMovements>()
                .Property(sm => sm.State)
                .HasDefaultValue(MovementState.Pending)
                .HasConversion<string>();
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<StockMovements> StockMovements { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<SuppliersItems> SuppliersItems { get; set; }
    public DbSet<TypeOfItem> Types { get; set; }
  }
}
