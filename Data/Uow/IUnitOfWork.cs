using Api.Services.CategoriesService;
using Api.Services.SuppliersService;
using Api.Services.UnitsService;

namespace Api.Data.Uow
{
    public interface IUnitOfWork
  {
    ICategoryService CategoriesService { get; }
    IUnitService UnitsService { get; }
    ISupplierService SuppliersService { get; }
    Task SaveAsync();
  }
}
