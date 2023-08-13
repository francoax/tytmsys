using Api.Services.GenericService;
using TyTManagmentSystem.Models;

namespace Api.Services.CategoryService
{
    public interface ICategoryService : IGenericService<Category>
    {
      ICollection<Item> GetItems();
    }
}
