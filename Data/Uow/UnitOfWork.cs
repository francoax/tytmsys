using TyTManagmentSystem.DataAccess;

namespace TyTManagmentSystem.Data.Uow
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly TyTContext _context;

    public UnitOfWork(TyTContext context)
    {
      _context = context;
    }
  }
}
