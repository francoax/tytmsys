using System.ComponentModel.DataAnnotations;

namespace Api.DTOs
{
  public class ItemForCreationDto
  {
    [Required]
    public int CategoryId { get; set; }
    [Required]
    [StringLength(maximumLength:150)]
    public string Name { get; set; } = null!;
    [Required]
    public int UnitId { get; set; }
    public List<int>? Suppliers { get; set; } = new List<int>();
  }
}
