using Api.Services.CategoriesService;
using Api.Services.ItemsService;
using Api.Services.StockMovementsService;
using Api.Services.SuppliersService;
using Api.Services.UnitsService;

namespace Api.Data.Uow
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly TyTContext context;
    public ICategoryService CategoriesService { get; private set; }
    public IUnitService UnitsService { get; private set; }
    public ISupplierService SuppliersService { get; private set; }
    public IItemService ItemsService { get; private set; }
    public IStockMovementService StockMovementsService { get; private set; }
    public UnitOfWork(TyTContext context)
    {
      this.context = context;
      CategoriesService = new CategoriesService(context);
      UnitsService = new UnitsService(context);
      SuppliersService = new SuppliersService(context);
      ItemsService = new ItemsService(context);
      StockMovementsService = new StockMovementsService(context);
    }
    public async Task SaveAsync()
    {
        await context.SaveChangesAsync();
    }
  }
}
