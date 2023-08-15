namespace Api.Models
{
  public class Category : ModelBase
  {
    public string Name { get; set; } = null!;
    public List<Item> Items { get; set; } = new List<Item>();
  }
}
