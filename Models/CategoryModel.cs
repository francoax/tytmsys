namespace Api.Models
{
  public class CategoryModel : BaseModel
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public IList<ItemModel> Items { get; set; }
  }
}
