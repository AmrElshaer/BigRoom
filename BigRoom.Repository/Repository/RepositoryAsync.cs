using BigRoom.Repository.Common;
using BigRoom.Repository.Contexts;
using BigRoom.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BigRoom.Repository.Repository
{
    public class RepositoryAsync<T>: IRepositoryAsync<T> where T : Entity
    {
        private readonly BigRoomDbContext _dbContext;

        public RepositoryAsync(BigRoomDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> Entities => _dbContext.Set<T>();

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }

      

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null)
        {
            var result = _dbContext.Set<T>().AsNoTracking();
            if (expression != null)
                result = result.Where(expression);
            return result;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> GetFirstAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(expression);
        }

        public Task UpdateAsync(T entity)
        {
            _dbContext.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}
