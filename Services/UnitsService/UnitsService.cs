using Api.Data;
using Api.Models;
using Api.Services.GenericService;

namespace Api.Services.UnitsService
{
  public class UnitsService : GenericService<Unit>, IUnitService
  {
    public UnitsService(TyTContext context) : base(context)
    {
    }
  }
}
