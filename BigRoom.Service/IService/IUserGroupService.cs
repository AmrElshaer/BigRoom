using BigRoom.Repository.Entities;
using BigRoom.Service.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BigRoom.Service.IService
{
    public interface IUserGroupService:IServiceAsync<UserGroups,UserGroupsDto>
    {
        IEnumerable<UserGroupsDto> GetUserInGroup(int groupId);
    }
}
