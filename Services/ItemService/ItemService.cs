using Api.Services.GenericService;
using TyTManagmentSystem.DataAccess;
using TyTManagmentSystem.Models;

namespace Api.Services.ItemService
{
  public class ItemService : GenericService<Item>, IItemService
  {
    public ItemService(TyTContext context) : base(context)
    {
    }
  }
}
