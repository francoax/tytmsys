using Api.Data;
using Api.Models;
using Api.Services.GenericService;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.CategoriesService
{
  public class CategoriesService : GenericService<Category>, ICategoryService
  {
    public CategoriesService(TyTContext context) : base(context)
    {
    }
    public override async Task<List<Category>> GetAllAsync() => await context.Categories.Include(c => c.Items).ToListAsync();
    public override async Task<Category?> GetAsync(int id) => await context.Categories.Include(c => c.Items).Where(c => c.Id == id).FirstOrDefaultAsync();
  }
}
