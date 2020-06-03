using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class EfRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        protected readonly ConfigurationContext _dbContext;

        public EfRepository(ConfigurationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            entity.DateSaved = DateTime.Now;

            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<int> CountAsync(ICriteria<T> criteria)
        {
            return await ApplyCriteria(criteria).CountAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> FirstAsync(ICriteria<T> criteria)
        {
            return await ApplyCriteria(criteria).FirstAsync();
        }

        public async Task<T> FirstOrDefaultAsync(ICriteria<T> criteria)
        {
            return await ApplyCriteria(criteria).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(ICriteria<T> criteria)
        {
            return await ApplyCriteria(criteria).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            entity.DateSaved = DateTime.Now;

            _dbContext.Entry(entity).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync() > 0;
        }

        private IQueryable<T> ApplyCriteria(ICriteria<T> criteria)
        {
            return CriteriaEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), criteria);
        }
    }
}
