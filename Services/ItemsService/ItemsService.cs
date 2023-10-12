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
        .Include(i => i.StockMovements)
        .Include(i => i.Unit)
        .Include(i => i.Category)
        .Include(i => i.Suppliers)
        .FirstOrDefaultAsync(i => i.Id == id);
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

    //public override Item Update(Item item)
    //{
    //  if (item.Suppliers is not null)
    //  {
    //    foreach (var supplier in item.Suppliers)
    //    {
    //      context.Entry(supplier).State = EntityState.Unchanged;
    //    }
    //  }

    //  return context.Update(item).Entity;
    //}

    public override async Task<int> Delete(int id)
    {
      var smDelete = await context.StockMovements.Where(sm => sm.ItemId == id).ExecuteDeleteAsync();
      var iDelete = await context.Items.Where(i => i.Id == id).ExecuteDeleteAsync();
      return smDelete + iDelete;
    }

    public Item GetReferences(Item item)
    {
      context.Entry(item).Reference(i => i.Category).Load();
      context.Entry(item).Reference(i => i.Unit).Load();
      context.Entry(item).Collection(i => i.Suppliers).Load();

      return item;
    }
  }
}
