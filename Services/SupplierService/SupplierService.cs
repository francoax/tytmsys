using Api.Services.GenericService;
using TyTManagmentSystem.DataAccess;
using TyTManagmentSystem.Models;

namespace Api.Services.SupplierService
{
  public class SupplierService : GenericService<Supplier>, ISupplierService
  {
    public SupplierService(TyTContext context) : base(context)
    {
    }
  }
}
