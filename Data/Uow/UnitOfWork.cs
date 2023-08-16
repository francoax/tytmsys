using Api.Services.CategoriesService;

namespace Api.Data.Uow
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly TyTContext context;
    public ICategoryService CategoriesService { get; private set; }
    public UnitOfWork(TyTContext context)
    {
      this.context = context;
      CategoriesService = new CategoriesService(context);
    }
    public async Task SaveAsync()
    {
        await context.SaveChangesAsync();
    }
  }
}
