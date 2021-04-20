using BigRoom.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BigRoom.Repository.IRepository
{
    public interface IUserGroupRepository : IRepositoryAsync<UserGroups>
    {
       Task<bool> UserIsJoinGroup(int groupId, int userId);
    }
}
