namespace Api.Models
{
    public class TypeOfItemModel : BaseModel
    {
        public string Description { get; set; }
        public IList<ItemModel> Items { get; set; }
    }
}
