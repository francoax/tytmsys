using Api.Data;
using Api.DTOs.StockMovementDTOs;
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

    public override async Task<List<StockMovement>> GetAllAsync()
    {
      return await context.StockMovements
        .Include(sm => sm.Item)
          .ThenInclude(i => i.Unit)
        .ToListAsync();
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

    public List<StockMovementDto> OrderStockMovements(List<StockMovementDto> movements)
    {
      return movements
        .OrderByDescending(sm => sm.DateOfAction.Date)
          .ThenByDescending(sm => sm.DateOfAction.TimeOfDay)
        .ToList();
    }
  }
}
