using Api.Services.CategoryService;
using Api.Services.ItemService;
using Api.Services.SupplierService;

namespace Api.Data.Uow
{
    public interface IUnitOfWork
    {
      ICategoryService CategoryService { get; }
      IItemService ItemService { get; }
      ISupplierService SupplierService { get; }
      Task SaveAsync();
    }
}
