using BigRoom.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BigRoom.Repository.IRepository
{
    public interface IUserProfileRepository:IRepositoryAsync<UserProfile>
    {
      Task<UserProfile>  GetUserProfileAsync(string identityId);
        Task<int> GetUserIdAsync(string identityId);
    }
}
