using Api.Services.CategoryService;
using Api.Services.ItemService;
using Api.Services.SupplierService;
using TyTManagmentSystem.DataAccess;

namespace TyTManagmentSystem.Data.Uow
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly TyTContext _context;
    public ICategoryService CategoryService { get; set; }
    public IItemService ItemService { get; set; }
    public ISupplierService SupplierService { get; set; }

    public UnitOfWork(TyTContext context)
    {
      _context = context;
      CategoryService = new CategoryService(context);
      ItemService = new ItemService(context);
      SupplierService = new SupplierService(context);
    } 
    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
    }
}
