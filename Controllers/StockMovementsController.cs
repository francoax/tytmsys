using Api.Data.Uow;
using Api.DTOs.StockMovementDTOs;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
  [ApiController]
  [Route("/api/items/movements")]
  public class StockMovementsController : ControllerBase
  {
    private readonly IUnitOfWork uow;
    private readonly IMapper mapper;

    public StockMovementsController(IUnitOfWork uow, IMapper mapper)
    {
      this.uow = uow;
      this.mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
      var movements = await uow.StockMovementsService.GetAllAsync();

      var movementsDto = mapper.Map<StockMovementsDto[]>(movements);

      movementsDto = movementsDto.OrderByDescending(sm => sm.DateOfAction.Date).ToArray();

      return Ok(new
      {
        message = "Movements list.",
        data = movementsDto,
        error = false
      });
    }

    [HttpGet("{itemId:int}")]
    public async Task<ActionResult> Get(int itemId)
    {
      var movements = await uow.StockMovementsService.GetMovementsOfItem(itemId);

      var itemMovements = mapper.Map<StockMovementDto[]>(movements);

      itemMovements = itemMovements.OrderByDescending(sm => sm.DateOfAction.Date).ToArray();

      return Ok(new
      {
        message = "Movements of item specified.",
        data = itemMovements,
        error = false
      });
    }

    [HttpPost]
    [Route("deposit/{itemId:int}")]
    public async Task<ActionResult> CreateStockForDeposit(int itemId, [FromBody] StockMovementForDeposit stockDeposit)
    {
      var newSm = mapper.Map<StockMovement>(stockDeposit);

      newSm.ItemId = itemId;

      uow.StockMovementsService.Add(newSm);

      await uow.SaveAsync();

      return Created($"http://localhost:7052/api/items/{itemId}/movements", new
      {
        message = "Movement for item added.",
        error = false
      });
    }

    [HttpPost]
    [Route("withdraw/{itemId:int}")]
    public async Task<ActionResult> CreateStockForWithdraw(int itemId, [FromBody] StockMovementForWithdraw stockWithDraw)
    {
      var stocks = await uow.StockMovementsService.GetActualStock(itemId);

      if (!stocks.Any()) return BadRequest(new
      {
        message = "The item does not contain movements to do a withdraw.",
        error = true
      });

      var actualStock = stocks.Sum(s => s.ActualStock);

      if (actualStock < stockWithDraw.Amount) return BadRequest(new
      {
        message = "There is not enough stock available.",
        error = true
      });

      if (uow.StockMovementsService.HasPendingMovements(itemId)) return BadRequest(new
      {
        message = "There are pending withdraw movements to confirm.",
        error = true
      });

      var newSm = mapper.Map<StockMovement>(stockWithDraw);

      newSm.ItemId = itemId;

      uow.StockMovementsService.Add(newSm);

      await uow.SaveAsync();

      return Created($"http://localhost:7052/api/items/{itemId}/movements", new
      {
        message = "Movement for item added.",
        error = false
      });
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, [FromBody] StockMovementForUpdate stockMovementForUpdate)
    {
      var stockToUpdate = await uow.StockMovementsService.GetAsync(id);
      if (stockToUpdate is null) return NotFound(new
      {
        message = "Movement not found",
        error = true
      });

      if (stockToUpdate.Amount < stockMovementForUpdate.RealAmountUsed) return BadRequest(new
      {
        message = "The real amount used doest not make sense with the amount retired.",
        error = true
      });

      mapper.Map(stockMovementForUpdate, stockToUpdate);

      uow.StockMovementsService.Update(stockToUpdate);

      await uow.SaveAsync();

      return Ok(new
      {
        message = "Movement of withdraw confirmed.",
        error = false
      });
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(int id)
    {
      var deleted = await uow.StockMovementsService.Delete(id);
      if (deleted is 0) return NotFound(new
      {
        message = "Movement not found",
        error = true
      });

      return Ok(new
      {
        message = "Movement deleted.",
        error = false
      });
    }
  }
}
