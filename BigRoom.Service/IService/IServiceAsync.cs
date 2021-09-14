using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BigRoom.Service.IService
{
    public interface IServiceAsync<TEntity, TDto>
    {
        Task<int> AddAsync(TDto tDto);

        Task DeleteAsync(int id);

        IEnumerable<TDto> GetAll(Expression<Func<TDto, bool>> expression = null);

        Task<TDto> GetByIdAsync(int id);

        Task<int> UpdateAsync(TDto entityTDto);
        Task<TDto> GetFirstAsync(Expression<Func<TDto, bool>> expression);
    }
}