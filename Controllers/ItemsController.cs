using Api.Data.Uow;
using Api.DTOs.CategoryDTOs;
using Api.DTOs.ItemDTOs;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
  [ApiController]
  [Route("/api/items")]
  public class ItemsController : ControllerBase
  {
    private readonly IUnitOfWork uow;
    private readonly IMapper mapper;

    public ItemsController(IUnitOfWork uow, IMapper mapper)
    {
      this.uow = uow;
      this.mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
      var items = await uow.ItemsService.GetAllAsync();
      var itemsDto = mapper.Map<ItemDto[]>(items);

      var stocks = await uow.StockMovementsService.GetActualStock();

      foreach (var item in itemsDto)
      {
        foreach (var stock in stocks)
        {
          if (stock.ItemId == item.Id)
          {
            item.ActualStock = stock.ActualStock;
          }
        }
      }

      foreach (var item in itemsDto)
      {
        item.StockMovements = uow.StockMovementsService.OrderStockMovements(item.StockMovements);
      }
      return Ok(new
      {
        message = "Items list.",
        data = itemsDto,
        error = false
      });
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> Get(int id)
    {
      var item = await uow.ItemsService.GetAsync(id);
      if (item is null) return NotFound(new
      {
        message = "Item not found.",
        error = true
      });

      var itemDto = mapper.Map<ItemDto>(item);

      itemDto.StockMovements = uow.StockMovementsService.OrderStockMovements(itemDto.StockMovements);

      var stock = await uow.StockMovementsService.GetActualStock(id);

      if (stock.Any())
      {
        itemDto.ActualStock = stock.FirstOrDefault(s => s.ItemId == itemDto.Id).ActualStock;
      }

      return Ok(new
      {
        message = $"Item {item.Name} found.",
        data = itemDto,
        error = false
      });
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody]ItemForCreationDto itemForCreation)
    {
      var newItem = mapper.Map<Item>(itemForCreation);
      
      uow.ItemsService.Add(newItem);

      await uow.SaveAsync();

      var itemCreated = await uow.ItemsService.GetAsync(newItem.Id);

      ItemDto item = mapper.Map<ItemDto>(itemCreated);

      return Ok(new
      {
        message = "Producto creado",
        data = item,
        error = false
      });
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, [FromBody] ItemForUpdateDto itemModified)
    {
      var itemToUpdate = await uow.ItemsService.GetAsync(id);
      if(itemToUpdate == null) {
        return NotFound(new
        {
          message = "Producto no encontrado",
          data = id,
          error = true
        });
      }
      try
      {
        var suppsToRemove = itemToUpdate.Suppliers.Where(supplier => !itemModified.Suppliers.Any(sup => sup.SupplierId == supplier.Id)).ToList();
        foreach(var sup in suppsToRemove)
        {
          itemToUpdate.Suppliers.Remove(sup);
        }

        foreach (var supplier in itemModified.Suppliers)
        {
          if (!itemToUpdate.Suppliers.Select(sup => sup.Id).Contains(supplier.SupplierId))
          {
            var sup = await uow.SuppliersService.GetAsync(supplier.SupplierId);
            if (sup is null) { continue; }

            itemToUpdate.Suppliers.Add(sup);
          }
        }

        mapper.Map(itemModified, itemToUpdate);

        uow.ItemsService.Update(itemToUpdate);

        await uow.SaveAsync();

        ItemDto item = mapper.Map<ItemDto>(itemToUpdate);

        item.Category = (await uow.CategoriesService.GetAsync(itemToUpdate.CategoryId)).Name;
        item.Unit = (await uow.UnitsService.GetAsync(itemToUpdate.UnitId)).Description;

        return Ok(new
        {
          message = "Producto actualizado",
          data = item,
          error = false
        });
      } catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
      var deleted = await uow.ItemsService.Delete(id);
      if (deleted == 0) return NotFound(new
      {
        message = "Producto no encontrado",
        data = id,
        error = true
      });

      return Ok(new
      {
        message = "Producto eliminado",
        data = id,
        error = false
      });
    }
  }
}
