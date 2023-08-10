namespace TyTManagmentSystem.Models
{
  public class Item : ModelBase
  {
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public ICollection<Supplier> Suppliers { get; set; }
    public ICollection<Price> PriceHistory { get; set; }
    public ICollection<Inventory> StockHistory { get; set; }
  }
}
