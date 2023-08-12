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

        public async Task<TEntity?> Get(int id)
        {
            return await entitySet.FirstOrDefaultAsync(e => e.Id == id);            
        }

        public async Task<ICollection<TEntity>> GetAll()
        {
            return await entitySet.ToListAsync();
        }

        public TEntity Update(TEntity entity)
        {
            return entitySet.Update(entity).Entity;
        }
    }
}