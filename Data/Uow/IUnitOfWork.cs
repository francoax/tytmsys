namespace Api.Data.Uow
{
    public interface IUnitOfWork
    {
      Task SaveAsync();
    }
}
