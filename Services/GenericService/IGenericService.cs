using Api.Models;

namespace Api.Services.GenericService
{
    public interface IGenericService<TEntity> where TEntity : BaseModel 
    {
        Task<TEntity?> Get(int id);
        Task<List<TEntity>> GetAll();
        Task<TEntity> Add(TEntity entity);
        TEntity Update(TEntity entity);
        Task<TEntity?> Delete(int id);
    }
}
