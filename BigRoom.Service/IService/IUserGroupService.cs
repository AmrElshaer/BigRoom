using BigRoom.Service.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BigRoom.Service.IService
{
    public interface IUserGroupService
    {
        bool IsExist(string codeJoin);
        bool UserIsJoinGroup(int groupId, int userId);
        Task CreateUserGroup(UserGroupsDto userGroupsDto);
    }
}
