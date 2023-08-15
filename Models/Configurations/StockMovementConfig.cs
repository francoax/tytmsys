using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Models.Configurations
{
  public class StockMovementConfig : IEntityTypeConfiguration<StockMovement>
  {
    public void Configure(EntityTypeBuilder<StockMovement> builder)
    {
    }
  }
}
