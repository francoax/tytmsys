namespace Api.Models
{
  public class Supplier : ModelBase
  {
    public string Name { get; set; } = null!;
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public Direction? Direction { get; set; }
    public List<ItemSupplier> ItemsSuppliers { get; set; } = new List<ItemSupplier>();
  }

  public class Direction
  {
    public string Street { get; set; } = null!;
    public string City { get; set; } = null!;
    public string StreetNumber { get; set; } = null!;
  }
}
