namespace Api.DTOs.SupplierDTOs
{
  public class SupplierDto
  {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public DirectionDto? Direction { get; set; }
    public List<ItemSupplier> Items { get; set; } = new List<ItemSupplier>();
  }

  public class ItemSupplier
  {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
  }
}
