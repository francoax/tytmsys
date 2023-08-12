using TyTManagmentSystem.Models;

namespace Api.Models
{
    public class SuppliersItems
    {
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int SupplierId { get; set;}
        public Supplier Supplier { get; set; }
    }
}
