namespace TyTManagmentSystem.Models
{
  public class Inventory
  {
    public int ItemId { get; set; }
    public DateTime Stock_at_Date { get; set; }
    public int Stock { get; set; }
    public Item Item { get; set; }
  }
}
