﻿using Api.Services.CategoriesService;
using Api.Services.UnitsService;

namespace Api.Data.Uow
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly TyTContext context;
    public ICategoryService CategoriesService { get; private set; }
    public IUnitService UnitsService { get; private set; }
    public UnitOfWork(TyTContext context)
    {
      this.context = context;
      CategoriesService = new CategoriesService(context);
      UnitsService = new UnitsService(context);
    }
    public async Task SaveAsync()
    {
        await context.SaveChangesAsync();
    }
  }
}
