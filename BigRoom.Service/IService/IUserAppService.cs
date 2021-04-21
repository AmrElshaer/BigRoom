using BigRoom.Repository.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BigRoom.Service.IService
{
    public  interface IUserAppService
    {
        Task<ApplicationUser> GetUserById(string id);
    }
}
