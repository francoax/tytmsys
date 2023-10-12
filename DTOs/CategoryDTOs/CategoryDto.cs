using Api.DTOs.ItemDTOs;

namespace Api.DTOs.CategoryDTOs
{
  public class CategoryDto
  {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<ItemDto> Items { get; set; } = new List<ItemDto>();
  }
}
