using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
  public class TyTContext : DbContext
  {
    public TyTContext(DbContextOptions options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<SuppliersItemsModel>()
            .HasKey(si => new { si.SupplierId, si.ItemId });

        modelBuilder.Entity<SupplierModel>(s =>
        {
            s.OwnsOne(sup => sup.Contact);
            s.OwnsOne(sup => sup.Address);
        });

        modelBuilder.Entity<StockMovementsModel>(sm =>
        {
            sm.HasKey(s => new { s.Id, s.ItemId });
            sm.Property(s => s.TotalPrice).HasPrecision(10, 2);
            sm.Property(s => s.Dollar_at_Date).HasPrecision(10, 2);
        });

        modelBuilder.Entity<ItemModel>()
            .HasOne(i => i.Type)
            .WithMany(ti => ti.Items)
            .HasForeignKey(i => i.TypeId);

        modelBuilder.Entity<ItemModel>()
            .HasMany(i => i.StockHistory)
            .WithOne(sm => sm.Item)
            .HasForeignKey(sm => sm.ItemId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<StockMovementsModel>()
            .Property(sm => sm.State)
            .HasDefaultValue(MovementState.Pending)
            .HasConversion<string>();
    }

    public DbSet<CategoryModel> Categories { get; set; }
    public DbSet<ItemModel> Items { get; set; }
    public DbSet<StockMovementsModel> StockMovements { get; set; }
    public DbSet<SupplierModel> Suppliers { get; set; }
    public DbSet<SuppliersItemsModel> SuppliersItems { get; set; }
    public DbSet<TypeOfItemModel> Types { get; set; }
  }
}
