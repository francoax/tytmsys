using Api.Data;
using Microsoft.EntityFrameworkCore;
using Api.Models;

namespace Api.Services.GenericService
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : BaseModel
    {
        protected TyTContext context;
        internal DbSet<TEntity> entitySet;

        public GenericService(TyTContext context)
        {
            this.context = context;
            entitySet = context.Set<TEntity>();
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            var entityNew = await entitySet.AddAsync(entity);
            return entityNew.Entity;
        }

        public async Task<TEntity?> Delete(int id)
        {
            var entityToDelete = await entitySet.FirstOrDefaultAsync(e => e.Id == id);
            if(entityToDelete != null)
            {
                return entitySet.Remove(entityToDelete).Entity;
            }
            return null;
        }

        public virtual async Task<TEntity?> Get(int id)
        {
            return await entitySet.FirstOrDefaultAsync(e => e.Id == id);            
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await entitySet.ToListAsync();
        }

        public TEntity Update(TEntity entity)
        {
            return entitySet.Update(entity).Entity;
        }
    }
}