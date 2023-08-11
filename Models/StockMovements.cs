namespace TyTManagmentSystem.Models
{
  public class StockMovements : ModelBase
  {
    public int ItemId { get; set; }
    public Item Item { get; set; }
    public string ActionType { get; set; }
    public int Amount { get; set; }
    public DateTime DateOfAction { get; set; }
    public int RealAmountUsed { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal Dollar_at_Date { get; set; }
    public MovementState State { get; set; }
  }

  public enum MovementState
    {
        Pending,
        Confirmed
    }
}
