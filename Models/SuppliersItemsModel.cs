namespace Api.Models
{
    public class SuppliersItemsModel
    {
        public int ItemId { get; set; }
        public ItemModel Item { get; set; }
        public int SupplierId { get; set;}
        public SupplierModel Supplier { get; set; }
    }
}
