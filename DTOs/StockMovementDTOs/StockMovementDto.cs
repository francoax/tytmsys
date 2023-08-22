namespace Api.DTOs.StockMovementDTOs
{
    public class StockMovementDto
    {
        public int Id { get; set; }
        public string Action { get; set; } = null!;
        public int Amount { get; set; }
        public int RealAmountUsed { get; set; }
        public string State { get; set; } = null!;
        public decimal TotalPrice { get; set; }
        public decimal DollarAtDate { get; set; }
        public DateTime DateOfAction { get; set; }
    }
}
