namespace Api.Models
{
  public class StockMovement : ModelBase
  {
    public string Action { get; set; } = null!;
    public int Amount { get; set; }
    public int RealAmountUsed { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal DollarAtDate { get; set; }
    public string State { get; set; } = null!;
    public DateTime DateOfAction { get; set; }
    public int ItemId { get; set; }
    public Item Item { get; set; } = null!;
  }
}
