using BigRoom.Repository.Contexts;
using BigRoom.Repository.IRepository;
using BigRoom.Service.IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BigRoom.Service.Service
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserAppRepository userAppRepository;

        public UserAppService(IUserAppRepository userAppRepository)
        {
            this.userAppRepository = userAppRepository;
        }
        public async Task<ApplicationUser> GetUserById(string id)
        {
            return await userAppRepository.GetUserById(id);
        }
    }
}
