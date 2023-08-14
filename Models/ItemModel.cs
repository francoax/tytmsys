namespace Api.Models
{
  public class ItemModel : BaseModel
  {
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public CategoryModel Category { get; set; }
    public int TypeId { get; set; }
    public TypeOfItemModel Type { get; set; }
    public IList<SupplierModel> Suppliers { get; set; }
    public IList<StockMovementsModel> StockHistory { get; set; }
  }
}
