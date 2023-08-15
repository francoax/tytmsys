using System.ComponentModel.DataAnnotations;

namespace Api.DTOs
{
  public class CategoryForCreationDto
  {
    [Required]
    public string Name { get; set; } = null!;
  }
}
