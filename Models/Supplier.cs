namespace TyTManagmentSystem.Models
{
  public class Supplier : ModelBase
  {
    public string Name { get; set; }
    public string CUIT { get; set; }
    public Address Address { get; set; }
    public Contact Contact { get; set; }
    public ICollection<Item> Items { get; set; }
  }

  public class Address
  {
    public string Street { get; set; }
    public int StreetNumber { get; set; }
    public string City { get; set; }
  }

  public class Contact
  {
    public string Phone { get; set; }
    public string Email { get; set; }
  }
}
