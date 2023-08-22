using System.ComponentModel.DataAnnotations;

namespace Api.DTOs.StockMovementDTOs
{
    public class StockMovementForDeposit
    {
        [Required]
        public int Amount { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        public decimal DollarAtDate { get; set; }

    }
}
