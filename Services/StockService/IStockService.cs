using Api.Services.GenericService;
using TyTManagmentSystem.Models;

namespace Api.Services.StockService
{
  public interface IStockService : IGenericService<StockMovements>
  {
    int GetActualStock(int id);
    ICollection<StockMovements> GetStockMovementsOnPending();
    ICollection<StockMovements> GetStockMovementsOnPending(int id);
  }
}
