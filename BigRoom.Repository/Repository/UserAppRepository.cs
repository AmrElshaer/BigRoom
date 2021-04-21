using BigRoom.Repository.Contexts;
using BigRoom.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BigRoom.Repository.Repository
{
    public class UserAppRepository : IUserAppRepository
    {
        private readonly BigRoomDbContext _context;

        public UserAppRepository(BigRoomDbContext context)
        {
            this._context = context;
        }
        public async Task<ApplicationUser> GetUserById(string id)
        {
          return await this._context.Users.FindAsync(id);
        }
    }
}
