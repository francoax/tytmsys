namespace TyTManagmentSystem.Models
{
  public class Category : ModelBase
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Item> Items { get; set; }
  }
}
