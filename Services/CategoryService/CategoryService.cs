using Api.Services.GenericService;
using TyTManagmentSystem.DataAccess;
using TyTManagmentSystem.Models;

namespace Api.Services.CategoryService
{
    public class CategoryService : GenericService<Category>, ICategoryService
    {
        public CategoryService(TyTContext context) : base(context)
        {
        }
    }
}
