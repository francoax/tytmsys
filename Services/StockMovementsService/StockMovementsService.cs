using Api.Data;
using Api.Models;
using Api.Services.GenericService;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.StockMovementsService
{
  public class StockMovementsService : GenericService<StockMovement>, IStockMovementService
  {
    public StockMovementsService(TyTContext context) : base(context)
    {
    }

    public async Task<List<ItemActualStock>> GetActualStock(int? itemId = null)
    {
      var stocks = await context.ItemStock.FromSqlInterpolated($"EXEC GetStockForItem {itemId}").ToListAsync();
      return stocks.Select(s => new ItemActualStock
      {
        ItemId = s.ItemId,
        ActualStock = s.ActualStock,
      }).ToList();
    }

    public async Task<List<StockMovement>> GetMovementsOfItem(int id)
    {
      return await context.StockMovements.Where(sm => sm.ItemId == id).ToListAsync();
    }

    public bool HasPendingMovements(int id)
    {
      var stocks = context.StockMovements.Where(sm => sm.ItemId == id && sm.State.Equals("pendiente")).GroupBy(sm => sm.ItemId).Count();
      return stocks > 0;
    }
  }
}
