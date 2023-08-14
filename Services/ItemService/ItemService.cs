using Api.Data;
using Api.Services.GenericService;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.ItemService
{
    public class ItemService : GenericService<ItemModel>, IItemService
  {
    public ItemService(TyTContext context) : base(context)
    {
    }
    public override async Task<List<ItemModel>> GetAll()
    {
      return await context.Items.Include(i => i.Category).Include(i => i.Type).Include(i => i.Suppliers).Include(i => i.StockHistory).ToListAsync();
    }
    public override async Task<ItemModel?> Get(int id)
    {
      return await context.Items.Include(i => i.Type).Include(i => i.Category).FirstOrDefaultAsync(i => i.Id == id);
    }

    public List<StockMovementsModel> GetStockHistoryForItem(int id)
    {
      return context.StockMovements.Where(sm => sm.ItemId == id).IgnoreAutoIncludes().ToList();
    }

    public List<SupplierModel> GetSuppliersForItem(int id)
    {
      throw new NotImplementedException();
    }

    public TypeOfItemModel GetTypeOfItem(int id)
    {
      throw new NotImplementedException();
    }
  }
}
