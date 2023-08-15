using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Api.DTOs
{
  public class StockMovementForCreationDto
  {
    [Required]
    public int ItemId { get; set; }
    [Required]
    public int Amount { get; set; }
    [Required]
    public decimal TotalPrice { get; set; }
    [Required]
    public decimal DollarAtDate { get; set; }

  }
}
