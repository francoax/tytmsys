using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Models.Configurations
{
  public class ItemSupplierConfig : IEntityTypeConfiguration<ItemSupplier>
  {
    public void Configure(EntityTypeBuilder<ItemSupplier> builder)
    {
      builder.HasKey(si => new { si.ItemId, si.SupplierId });
    }
  }
}
