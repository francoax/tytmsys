using Microsoft.EntityFrameworkCore;
using TyTManagmentSystem.DataAccess;
using TyTManagmentSystem.Models;

namespace Api.Services.GenericService
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : ModelBase
    {
        protected TyTContext _context;
        internal DbSet<TEntity> entitySet;

        public GenericService( TyTContext context )
        {
            _context = context;
            entitySet = context.Set<TEntity>();
        }

        public TEntity? Get(int id)
        {
            return entitySet.Where(e => e.Id == id).FirstOrDefault();
        }

        public ICollection<TEntity> GetAll()
        {
            return entitySet.ToList();
        }

        public TEntity Add(TEntity entity)
        {
            return entitySet.Add(entity).Entity;
        }

        public TEntity Update(TEntity entity)
        {
            return entitySet.Update(entity).Entity;
        }

        public TEntity Delete(int id)
        {
            var entity = entitySet.FirstOrDefault(e => e.Id == id);
            if(entity != null) 
            {
                entitySet.Remove(entity);
            }
        }
    }
}