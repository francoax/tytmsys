using System.ComponentModel.DataAnnotations;

namespace Api.DTOs.UnitDTOs
{
    public class UnitForCreationDto
    {
        [Required]
        public string Description { get; set; } = null!;
    }
}
