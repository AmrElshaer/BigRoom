using BigRoom.Service.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BigRoom.Service.IService
{
    public interface IUserProfileService
    {
        Task AddUserProfileAsync(string userId);
        Task<int> GetUserProfileIdAsync(string identityId);
        Task<UserProfileDto> GetUserProfileAsync(int id);
    }
}
