using Api.Models;
using Api.Services.GenericService;
using TyTManagmentSystem.Models;

namespace Api.Services.ItemService
{
  public interface IItemService : IGenericService<Item>
  {
    ICollection<Supplier> GetSuppliers();
    Supplier GetSupplier(int id);
    TypeOfItem GetTypeOfItem();
    ICollection<StockMovements> GetStockHistory();
  }
}
