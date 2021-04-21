using BigRoom.Repository.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BigRoom.Repository.IRepository
{
    public interface IUserAppRepository
    {
        Task<ApplicationUser> GetUserById(string id);
    }
}
