namespace Api.Dto
{
  public class ItemForCreationDto
  {
    public string Name { get; set; }
    public int? CategoryId { get; set; }
    public int TypeId { get; set; }
    public List<int> Suppliers { get; set; }
  }
}
