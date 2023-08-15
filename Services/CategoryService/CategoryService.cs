using Api.Data;
using Api.Services.GenericService;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.CategoryService
{
  public class CategoryService : GenericService<Category>, ICategoryService
  {
    public CategoryService(TyTContext context) : base(context)
    {
    }
  }
}
