using TyTManagmentSystem.Models;

namespace Api.Models
{
    public class TypeOfItem : ModelBase
    {
        public string Description { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
