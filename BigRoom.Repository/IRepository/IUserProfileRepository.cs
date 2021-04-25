using BigRoom.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BigRoom.Repository.IRepository
{
    public interface IUserProfileRepository:IRepositoryAsync<UserProfile>
    {
      Task<UserProfile>  GetUserProfileAsync(int id);
        Task<int> GetUserIdAsync(string identityId);
    }
}
