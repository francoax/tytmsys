using Api.Services.GenericService;
using TyTManagmentSystem.DataAccess;
using TyTManagmentSystem.Models;

namespace Api.Services.StockService
{
  public class StockService : GenericService<StockMovements>, IStockService
  {
    public StockService(TyTContext context) : base(context)
    {
    }
  }
}
