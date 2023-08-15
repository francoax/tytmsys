using System.ComponentModel.DataAnnotations;

namespace Api.DTOs
{
  public class UnitForCreationDto
  {
    [Required]
    public string Description { get; set; } = null!;
  }
}
