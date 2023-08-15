using Api.Services.CategoryService;
using Api.Services.ItemService;
using Api.Services.SupplierService;

namespace Api.Data.Uow
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly TyTContext context;
    public ICategoryService CategoryService { get; private set; }
    public IItemService ItemService { get; private set; }
    public ISupplierService SupplierService { get; private set; }

    public UnitOfWork(TyTContext context)
    {
      this.context = context;
      CategoryService = new CategoryService(context);
      ItemService = new ItemService(context);
      SupplierService = new SupplierService(context);
    }
    public async Task SaveAsync()
    {
        await context.SaveChangesAsync();
    }
  }
}
