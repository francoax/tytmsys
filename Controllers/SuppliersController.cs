using Api.Data.Uow;
using Api.DTOs;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
  [ApiController]
  [Route("/api/suppliers")]
  public class SuppliersController : ControllerBase
  {
    private readonly IUnitOfWork uow;
    private readonly IMapper mapper;

    public SuppliersController(IUnitOfWork uow, IMapper mapper)
    {
      this.uow = uow;
      this.mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
      return Ok(new
      {
        message = "Suppliers list.",
        data = await uow.SuppliersService.GetAllAsync(),
        error = false
      });
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> Get(int id)
    {
      var supplier = await uow.SuppliersService.GetAsync(id);
      if (supplier is null) return NotFound(new
      {
        message = "Supplier not found",
        error = true
      });

      return Ok(new
      {
        message = $"Supplier {supplier.Name} found.",
        data = supplier,
        error = false
      });
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody]SupplierForCreationDto supplierForCreation)
    {
      var newSupplier = mapper.Map<Supplier>(supplierForCreation);

      uow.SuppliersService.Add(newSupplier);

      await uow.SaveAsync();

      return Ok(new
      {
        message = "Supplier created.",
        data = newSupplier,
        error = false
      });
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, [FromBody]SupplierForUpdateDto supplierForUpdate)
    {
      var supplierToUpdate = await uow.SuppliersService.GetAsync(id);
      if (supplierToUpdate is null) return NotFound(new
      {
        message = "Supplier not found",
        error = true
      });
      mapper.Map(supplierForUpdate, supplierToUpdate);

      uow.SuppliersService.Update(supplierToUpdate);

      await uow.SaveAsync();

      return Ok(new
      {
        message = "Supplier updated",
        data = supplierToUpdate,
        error = false
      });
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
      var deleted = await uow.SuppliersService.Delete(id);
      if (deleted is 0) return NotFound(new
      {
        message = "Supplier not found.",
        error = true
      });

      return Ok(new
      {
        message = "Supplier deleted.",
        error = false
      });
    }
  }
}
