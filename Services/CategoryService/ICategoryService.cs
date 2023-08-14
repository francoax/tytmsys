using Api.Services.GenericService;
using Api.Models;

namespace Api.Services.CategoryService
{
    public interface ICategoryService : IGenericService<CategoryModel>
    {
      List<ItemModel>? GetItemsForCategory(int id);
      List<CategoryModel> GetCategoriesWithItems();
    }
}
