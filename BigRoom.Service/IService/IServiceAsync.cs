using BigRoom.Repository.Common;
using BigRoom.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace BigRoom.Service.IService
{
    public interface IServiceAsync<TEntity, TDto>
    {
        Task<int> AddAsync(TDto tDto);
        Task DeleteAsync(int id);
        IEnumerable<TDto> GetAllAsync(Func<TDto, bool> expression = null);
        Task<TDto> GetByIdAsync(int id);
        Task<int> UpdateAsync(TDto entityTDto);
    }
}
