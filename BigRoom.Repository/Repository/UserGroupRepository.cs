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
    public  class UserGroupRepository:RepositoryAsync<UserGroups>,IUserGroupRepository
    {
        public UserGroupRepository(BigRoomDbContext context):base(context)
        {

        }

        public async Task<bool> UserIsJoinGroup(int groupId, int userId)
        {
            return (await Entities.FirstOrDefaultAsync(a=>a.GroupId==groupId&&a.UserProfileId==userId))!=null?true:false;
        }
    }
}
