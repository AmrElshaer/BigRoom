using BigRoom.Model.Entities;
using BigRoom.Repository.Contexts;
using BigRoom.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigRoom.Repository.Repository
{
    public  class GroupRepository : RepositoryAsync<Group>, IGroupRepository
    {
        public GroupRepository(BigRoomDbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<bool> IsExistAsync(string codeJoin)
        {
            var group = await GetGroupByCodeAsync(codeJoin);
            return group != null ? true : false;
        }
        public async Task<Group> GetGroupByCodeAsync(string codeJoin)
        {
            var group = await Entities.FirstOrDefaultAsync(a => a.CodeJion == codeJoin);
            return group;
        }
        public async Task<bool> UniquesNameAsync(string name)
        {
            var user =await Entities.FirstOrDefaultAsync(a=>a.Name.ToLower().Contains(name.ToLower()));
            return user!=null?false:true;
        }
    }
}
