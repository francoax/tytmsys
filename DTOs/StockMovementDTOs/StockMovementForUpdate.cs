using System.ComponentModel.DataAnnotations;

namespace Api.DTOs.StockMovementDTOs
{
  public class StockMovementForUpdate
  {
    [Required]
    public int RealAmountUsed { get; set; }
  }
}
