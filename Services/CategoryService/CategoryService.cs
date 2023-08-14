using Api.Data;
using Api.Services.GenericService;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.CategoryService
{
  public class CategoryService : GenericService<CategoryModel>, ICategoryService
  {
    public CategoryService(TyTContext context) : base(context)
    {
    }
    public override async Task<List<CategoryModel>> GetAll()
    {
      return await context.Categories.Include(c => c.Items).ToListAsync();
    }
    public List<CategoryModel> GetCategoriesWithItems()
    {
      return context.Categories.Include(c => c.Items).ToList();
    }

    public List<ItemModel>? GetItemsForCategory(int id)
    {
      var category = context.Categories.Include(c => c.Items).FirstOrDefault(c => c.Id == id);
      if(category != null)
      {
        return category.Items.ToList();
      }
      return null;
    }
  }
}
