using Microsoft.EntityFrameworkCore;
using RentalCarInfrastructure.Context;
using RentalCarInfrastructure.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentalCarInfrastructure.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public async Task<bool> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            return _dbContext.SaveChanges() > 0;
        }

        public async Task<bool> AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(T entity)
        {
            _dbSet.Remove(entity);
            return await SaveAsync();
        }

        public async Task<bool> DeleteRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
            return await SaveAsync();
        }

        public async Task<IEnumerable<T>> GetAllRecord()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetARecord(string Id)
        {
            return await _dbSet.FindAsync(Id);
        }

        public async Task<bool> Update(T entity)
        {
            _dbSet.Update(entity);
            return await SaveAsync();
        }

        public async Task<bool> UpdateRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().UpdateRange(entities);
            return await SaveAsync();
        }

        private async Task<bool> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }

}
