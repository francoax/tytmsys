using Api.Data;
using Api.Services.GenericService;
using Api.Models;

namespace Api.Services.SupplierService
{
    public class SupplierService : GenericService<Supplier>, ISupplierService
  {
    public SupplierService(TyTContext context) : base(context)
    {
    }
  }
}
