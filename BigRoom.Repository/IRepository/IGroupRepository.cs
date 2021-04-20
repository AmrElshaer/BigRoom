using BigRoom.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BigRoom.Repository.IRepository
{
    public interface IGroupRepository : IRepositoryAsync<Group>
    {
        Task<bool> UniquesNameAsync(string name);
        Task<bool> IsExistAsync(string codeJoin);
        Task<Group> GetGroupByCodeAsync(string codeJoin);
    }
}
