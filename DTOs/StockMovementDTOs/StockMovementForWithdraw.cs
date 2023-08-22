using System.ComponentModel.DataAnnotations;

namespace Api.DTOs.StockMovementDTOs
{
    public class StockMovementForWithdraw
    {
        [Required]
        public int Amount { get; set; }
    }
}
