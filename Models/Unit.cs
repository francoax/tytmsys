namespace Api.Models
{
  public class Unit : ModelBase
  {
    public string Description { get; set; } = null!;
    public HashSet<Item> Items { get; set; } = new HashSet<Item>();
  }
}
