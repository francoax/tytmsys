using Api.Data;
using Api.Models;
using Api.Services.GenericService;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.ItemsService
{
  public class ItemsService : GenericService<Item>, IItemService
  {
    public ItemsService(TyTContext context) : base(context)
    {
    }

    public override async Task<List<Item>> GetAllAsync()
    {
      return await context.Items
        .Include(i => i.StockMovements)
        .Include(i => i.Suppliers)
        .Include(i => i.Unit)
        .Include(i => i.Category)
        .ToListAsync();
    }

    public override async Task<Item?> GetAsync(int id)
    {
      return await context.Items
        .Where(i => i.Id == id)
        .Include(i => i.StockMovements)       
        .Include(i => i.Suppliers)
        .Include(i => i.Unit)
        .Include(i => i.Category)
        .FirstOrDefaultAsync();
    }

    public override Item Add(Item item)
    {
      if(item.Suppliers is not null)
      {
        foreach(var supplier in item.Suppliers)
        {
          context.Entry(supplier).State = EntityState.Unchanged;
        }
      }

      return context.Add(item).Entity;
    }
  }
}
