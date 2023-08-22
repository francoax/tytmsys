using System.ComponentModel.DataAnnotations;

namespace Api.DTOs.SupplierDTOs
{
    public class SupplierForUpdateDto
    {
        public string? Name { get; set; }
        public string? Phone { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public DirectionDto? Direction { get; set; }
    }
    public class DirectionDto
    {
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? StreetNumber { get; set; }
    }
}
