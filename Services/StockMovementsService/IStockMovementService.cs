using Api.Models;
using Api.Services.GenericService;

namespace Api.Services.StockMovementsService
{
  public interface IStockMovementService : IGenericService<StockMovement>
  {
    Task<List<StockMovement>> GetMovementsOfItem(int id);
    bool HasPendingMovements(int id);
    Task<List<ItemActualStock>> GetActualStock(int? id = null);
  }
}
