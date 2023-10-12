using Api.Models;
using Api.Services.GenericService;

namespace Api.Services.ItemsService
{
  public interface IItemService : IGenericService<Item>
  {
    Item GetReferences(Item item);
  }
}
