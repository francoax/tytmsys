namespace TyTManagmentSystem.Models
{
  public class Price
  {
    public int ItemId { get; set; }
    public DateTime Date_Price { get; set; }
    public decimal Amount { get; set; }
    public Item Item { get; set; }
  }
}
