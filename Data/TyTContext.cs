using Microsoft.EntityFrameworkCore;

namespace TyTManagmentSystem.DataAccess
{
  public class TyTContext : DbContext
  {
    public TyTContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
    }
  }
}
