using Api.Models;

namespace Api.Services.GenericService
{
    public interface IGenericService<TEntity> where TEntity : ModelBase 
    {
        Task<TEntity> Add(TEntity entity);
        TEntity Update(TEntity entity);
        Task<TEntity?> Delete(int id);
    }
}
