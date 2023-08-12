using TyTManagmentSystem.Models;

namespace Api.Services.GenericService
{
    public interface IGenericService<TEntity> where TEntity : ModelBase 
    {
        Task<TEntity?> Get(int id);
        Task<ICollection<TEntity>> GetAll();
        Task<TEntity> Add(TEntity entity);
        TEntity Update(TEntity entity);
        Task<TEntity?> Delete(int id);
    }
}
