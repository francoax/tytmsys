using Api.Models;

namespace TyTManagmentSystem.Models
{
  public class Item : ModelBase
  {
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public int TypeId { get; set; }
    public TypeOfItem Type { get; set; }
    public ICollection<Supplier> Suppliers { get; set; }
    public ICollection<StockMovements> StockHistory { get; set; }
  }
}
