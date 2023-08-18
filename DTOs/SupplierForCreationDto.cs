using System.ComponentModel.DataAnnotations;

namespace Api.DTOs
{
  public class SupplierForCreationDto
  {
    [Required]
    public string Name { get; set; } = null!;
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public DirectionDto? Direction { get; set; }
  }
}
