using BigRoom.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BigRoom.Repository.IRepository
{
    public interface IDegreeRepository:IRepositoryAsync<Degree>
    {
        Task<bool> IsDoExamAsync(int id, int userId);
    }
}
