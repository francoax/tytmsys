using Api.Data;
using Api.Services.GenericService;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.ItemService
{
    public class ItemService : GenericService<Item>, IItemService
  {
    public ItemService(TyTContext context) : base(context)
    {
    }
  }
}
