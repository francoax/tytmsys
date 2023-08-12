using TyTManagmentSystem.Models;

namespace Api.Services.GenericService
{
    public interface IGenericService<TEntity> where TEntity : ModelBase 
    {
        TEntity? Get(int id);
        ICollection<TEntity> GetAll();
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Delete(int id);
    }
}
