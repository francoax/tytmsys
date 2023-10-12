using Api.Data.Uow;
using Api.DTOs.CategoryDTOs;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
  [ApiController]
  [Route("/api/categories")]
  public class CategoriesController : ControllerBase
  {
    private readonly IUnitOfWork uow;
    private readonly IMapper mapper;

    public CategoriesController(IUnitOfWork uow, IMapper mapper)
    {
      this.uow = uow;
      this.mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
      return Ok(new
      {
        message = "Categories list",
        data = await uow.CategoriesService.GetAllAsync(),
        error = false
      });
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> Get(int id)
    {
      var category = await uow.CategoriesService.GetAsync(id);
      if( category is null  ) return NotFound(new
      {
        message = "Category not found",
        error = true
      });

      return Ok(new
      {
        message = $"Category {category.Name}",
        data = category,
        error = false
      });
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody]CategoryForCreationDto categoryForCreation)
    {
      var newCategory = mapper.Map<Category>(categoryForCreation);

      uow.CategoriesService.Add(newCategory);

      await uow.SaveAsync();

      return Created($"https://localhost:7021/api/categories/{newCategory.Id}", new
      {
        message = $"Category {newCategory.Name} created",
        data = newCategory,
        error = false
      });
    }

    [HttpPost("many")]
    public async Task<ActionResult> Post([FromBody] CategoryForCreationDto[] categoriesForCreation)
    {
      var newCategories = mapper.Map<Category[]>(categoriesForCreation);

      uow.CategoriesService.AddMany(newCategories);

      await uow.SaveAsync();

      return Created("https://localhost:7021/api/categories", new
      {
        message = "Categories created.",
        data = newCategories,
        error = false
      });
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, [FromBody] CategoryForCreationDto categoryModified)
    {
      var categoryToUpdate = await uow.CategoriesService.GetAsync(id);
      if (categoryToUpdate is null) return NotFound(new
      {
        message = "Category not found",
        error = true
      });

      categoryToUpdate.Name = categoryModified.Name;

      uow.CategoriesService.Update(categoryToUpdate);

      await uow.SaveAsync();

      return Ok(new
      {
        message = $"Category {categoryToUpdate.Name} updated.",
        data = categoryToUpdate,
        error = false
      });
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
      var deleted = await uow.CategoriesService.Delete(id);
      if (deleted == 0) return NotFound(new
      {
        message = "Category not found",
        error = true
      });

      return Ok(new
      {
        message = "Category deleted.",
        error = false
      });
    }
  }
}
