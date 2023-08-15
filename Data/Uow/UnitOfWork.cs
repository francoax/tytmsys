namespace Api.Data.Uow
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly TyTContext context;
    public UnitOfWork(TyTContext context)
    {
      this.context = context;
    }
    public async Task SaveAsync()
    {
        await context.SaveChangesAsync();
    }
  }
}
