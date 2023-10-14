namespace Api.DTOs.SupplierDTOs
{
  public class SupplierDto
  {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Contact { get; set; } = string.Empty;
    public List<ItemSupplier> Items { get; set; } = new List<ItemSupplier>();
  }

  public class ItemSupplier
  {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
  }
}
