using Api.Services.CategoriesService;
using Api.Services.ItemsService;
using Api.Services.StockMovementsService;
using Api.Services.SuppliersService;
using Api.Services.UnitsService;

namespace Api.Data.Uow
{
    public interface IUnitOfWork
  {
    ICategoryService CategoriesService { get; }
    IUnitService UnitsService { get; }
    ISupplierService SuppliersService { get; }
    IItemService ItemsService { get; }
    IStockMovementService StockMovementsService { get; }
    Task SaveAsync();
  }
}
