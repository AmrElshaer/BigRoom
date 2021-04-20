using BigRoom.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BigRoom.Repository.IRepository
{
    public interface IRepositoryAsync<T> where T:Entity
    {
        Task<T> AddAsync(T entity);
        Task DeleteAsync(T entity);
        IQueryable<T> GetAllAsync(Expression<Func<T, bool>> expression = null);
        Task<T> GetByIdAsync(int id);
        Task UpdateAsync(T entity);
    }
}
