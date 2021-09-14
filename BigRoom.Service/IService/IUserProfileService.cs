using BigRoom.Repository.Entities;
using BigRoom.Service.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BigRoom.Service.IService
{
    public interface IUserProfileService:IServiceAsync<UserProfile,UserProfileDto>
    {
        Task<UserProfileDto> GetUserProfileAsync(int id);
    }
}
