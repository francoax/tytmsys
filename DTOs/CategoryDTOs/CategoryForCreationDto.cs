using System.ComponentModel.DataAnnotations;

namespace Api.DTOs.CategoryDTOs
{
    public class CategoryForCreationDto
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
