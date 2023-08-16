using Api.Models;

namespace Api.Services.GenericService
{
  public interface IGenericService<TEntity> where TEntity : ModelBase
  {
    Task<TEntity?> GetAsync(int id);
    Task<List<TEntity>> GetAllAsync();
    TEntity Add(TEntity entity);
    void AddMany(TEntity[] entities);
    TEntity Update(TEntity entity);
    Task<int> Delete(int id);
  }
}
