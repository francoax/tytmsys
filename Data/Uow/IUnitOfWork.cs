using Api.Services.CategoryService;
using Api.Services.ItemService;
using Api.Services.StockService;
using Api.Services.SupplierService;

namespace Api.Data.Uow
{
    public interface IUnitOfWork
    {
      ICategoryService CategoryService { get; }
      IItemService ItemService { get; }
      ISupplierService SupplierService { get; }
      IStockService StockService { get; }
      Task SaveAsync();
    }
}
