using Api.DTOs.StockMovementDTOs;

namespace Api.DTOs.ItemDTOs
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<string> Suppliers { get; set; } = new List<string>();
        public string Unit { get; set; } = null!;
        public string Category { get; set; } = null!;
        public int ActualStock { get; set; }
        public List<StockMovementDto> StockMovements { get; set; } = new List<StockMovementDto>();
    }
}
