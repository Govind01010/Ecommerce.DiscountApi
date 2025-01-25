using Discount.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Discount.Infrastructure.Data.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Domain.Entities.BaseEntity
    {
        private readonly AppDbContext _appDbContext;
        private DbSet<TEntity> _entitie;
        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _appDbContext.Set<TEntity>().AddAsync(entity);
            return entity;
        }

        public Task DeleteAsync(TEntity entity)
        {
            _appDbContext.Set<TEntity>().Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _appDbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var result = await _appDbContext.Set<TEntity>().FindAsync(id);
            if (result == null)
            {
                throw new Exception("Entity not found");
            }
            return result;
        }

        public Task UpdateAsync(TEntity entity)
        {
            _appDbContext.Set<TEntity>().Update(entity);
            return Task.CompletedTask;
        }
    }
}
