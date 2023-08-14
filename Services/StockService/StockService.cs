using Api.Data;
using Api.Services.GenericService;
using Api.Models;

namespace Api.Services.StockService
{
  public class StockService : GenericService<StockMovementsModel>, IStockService
  {
    public StockService(TyTContext context) : base(context)
    {
    }

    public int GetActualStock(int id)
    {
      throw new NotImplementedException();
    }

    public ICollection<StockMovementsModel> GetStockMovementsOnPending()
    {
      throw new NotImplementedException();
    }

    public ICollection<StockMovementsModel> GetStockMovementsOnPending(int id)
    {
      throw new NotImplementedException();
    }
  }
}
