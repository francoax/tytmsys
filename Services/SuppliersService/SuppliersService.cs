using Api.Data;
using Api.Models;
using Api.Services.GenericService;

namespace Api.Services.SuppliersService
{
  public class SuppliersService : GenericService<Supplier>, ISupplierService
  {
    public SuppliersService(TyTContext context) : base(context)
    {
    }
  }
}
