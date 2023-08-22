using System.ComponentModel.DataAnnotations;

namespace Api.DTOs.ItemDTOs
{
    public class ItemForCreationDto
    {
        [Required]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(maximumLength: 150)]
        public string Name { get; set; } = null!;
        [Required]
        public int UnitId { get; set; }
        public List<ItemSupplierForCreationDto>? Suppliers { get; set; } = new List<ItemSupplierForCreationDto>();
    }
}
