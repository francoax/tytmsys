using Api.Data;
using Microsoft.EntityFrameworkCore;
using Api.Models;

namespace Api.Services.GenericService
{
  public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : ModelBase
  {
    protected TyTContext context;
    internal DbSet<TEntity> entitySet;

    public GenericService(TyTContext context)
    {
        this.context = context;
        entitySet = context.Set<TEntity>();
    }

    public TEntity Add(TEntity entity) => entitySet.Add(entity).Entity;

    public void AddMany(TEntity[] entities) => entitySet.AddRange(entities);

    public async Task<int> Delete(int id) => await entitySet.Where(e => e.Id == id).ExecuteDeleteAsync();

    public TEntity Update(TEntity entity) => entitySet.Update(entity).Entity;
  }
}