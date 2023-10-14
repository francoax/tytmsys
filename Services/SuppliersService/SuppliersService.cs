using Api.Data;
using Api.Models;
using Api.Services.GenericService;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.SuppliersService
{
  public class SuppliersService : GenericService<Supplier>, ISupplierService
  {
    public SuppliersService(TyTContext context) : base(context)
    {
    }
    public override Task<Supplier?> GetAsync(int id)
    {
      return context.Suppliers.Include(s => s.Items).FirstOrDefaultAsync(s => s.Id == id);
    }
    public override Task<List<Supplier>> GetAllAsync()
    {
      return context.Suppliers.Include(s => s.Items).ToListAsync();
    }
  }
}
