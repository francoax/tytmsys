namespace Api.DTOs.StockMovementDTOs
{
  public class StockMovementsDto
  {
    public int Id { get; set; }
    public string Action { get; set; } = null!;
    public int Amount { get; set; }
    public int RealAmountUsed { get; set; }
    public string State { get; set; } = null!;
    public decimal TotalPrice { get; set; }
    public decimal DollarAtDate { get; set; }
    public DateTime DateOfAction { get; set; }
    public int ItemId { get; set; }
    public string Item { get; set; } = null!;
    public string ItemUnit { get; set; } = null!;
  }
}
