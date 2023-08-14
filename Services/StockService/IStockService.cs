using Api.Services.GenericService;
using Api.Models;

namespace Api.Services.StockService
{
  public interface IStockService : IGenericService<StockMovementsModel>
  {
    int GetActualStock(int id);
    ICollection<StockMovementsModel> GetStockMovementsOnPending();
    ICollection<StockMovementsModel> GetStockMovementsOnPending(int id);
  }
}
