using BigRoom.Service.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BigRoom.Service.IService
{
    public interface IGroupPermissionService
    {
        Task<IEnumerable<GroupPermissionDto>> GetGroupPermissions(int groupId);
        Task CreateEditAsync(GroupPermissionDto groupPermissionDto);
        Task<GroupPermissionDto> GetGroupPermissionById(int id);
    }
}
