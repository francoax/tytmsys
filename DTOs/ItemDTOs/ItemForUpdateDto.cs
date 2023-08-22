namespace Api.DTOs.ItemDTOs
{
    public class ItemForUpdateDto
    {
        public int CategoryId { get; set; }
        public int UnitId { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<ItemSupplierForCreationDto> Suppliers { get; set; } = new List<ItemSupplierForCreationDto>();
    }
}
