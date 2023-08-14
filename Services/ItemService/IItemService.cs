using Api.Models;
using Api.Services.GenericService;

namespace Api.Services.ItemService
{
  public interface IItemService : IGenericService<ItemModel>
  {
    List<SupplierModel> GetSuppliersForItem(int id);
    TypeOfItemModel GetTypeOfItem(int id);
    List<StockMovementsModel> GetStockHistoryForItem(int id);
  }
}
