using Api.Data.Uow;
using Api.DTOs.UnitDTOs;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
  [Route("/api/units")]
  public class UnitsController : ControllerBase
  {
    private readonly IUnitOfWork uow;
    private readonly IMapper mapper;

    public UnitsController(IUnitOfWork uow, IMapper mapper)
    {
      this.uow = uow;
      this.mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
      return Ok(new
      {
        message = "Units of item list",
        data = await uow.UnitsService.GetAllAsync()
      });
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] UnitForCreationDto unitForCreation)
    {
      var newUnit = mapper.Map<Unit>(unitForCreation);

      uow.UnitsService.Add(newUnit);

      await uow.SaveAsync();

      return Created("", new
      {
        message = $"Unit {newUnit.Description} created",
        data = newUnit,
        error = false
      });
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, [FromBody] UnitForCreationDto unitModified)
    {
      var unitToUpdate = await uow.UnitsService.GetAsync(id);
      if (unitToUpdate is null) return NotFound(new
      {
        message = "Unit not found",
        error = true
      });

      unitToUpdate.Description = unitModified.Description;

      uow.UnitsService.Update(unitToUpdate);
      
      await uow.SaveAsync();

      return Ok(new
      {
        message = "Unit updated.",
        data = unitToUpdate,
        error = false
      });
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
      var deleted = await uow.UnitsService.Delete(id);
      if (deleted is 0) return NotFound(new
      {
        message = "Unit not found.",
        error = true
      });

      return Ok(new
      {
        message = "Unit deleted.",
        error = false
      });
    }
  }
}
