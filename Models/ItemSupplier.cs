namespace Api.Models
{
  public class ItemSupplier
  {
    public int ItemId { get; set; }
    public Item Item { get; set; } = null!;
    public int SupplierId { get; set; }
    public Supplier Supplier { get; set; } = null!;
  }
}
