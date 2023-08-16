using Api.Services.CategoriesService;

namespace Api.Data.Uow
{
    public interface IUnitOfWork
  {
    ICategoryService CategoriesService { get; }
    Task SaveAsync();
  }
}
