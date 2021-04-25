using BigRoom.Model.Entities;
using BigRoom.Repository.Contexts;
using BigRoom.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BigRoom.Repository.Repository
{
    public class UserProfileRepository:RepositoryAsync<UserProfile>,IUserProfileRepository
    {
        public UserProfileRepository(BigRoomDbContext dbContext):base(dbContext)
        {
            
        }

        public async Task<int> GetUserIdAsync(string identityId)
        {
            return (await this.Entities.FirstOrDefaultAsync(a=>a.UserId==identityId)).Id;
        }

        public async Task<UserProfile> GetUserProfileAsync(int id)
        {
           return await  this.Entities.Include(a => a.GroupsThatAdmin).Include(a => a.Groups).ThenInclude(a => a.Group)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
