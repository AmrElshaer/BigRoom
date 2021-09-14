using BigRoom.Repository.Entities;
using BigRoom.Service.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BigRoom.Service.IService
{
    public interface IGroupPermissionService : IServiceAsync<GroupPermission, GroupPermissionDto>
    {
        IEnumerable<GroupPermissionDto> GetGroupPermissions(int groupId);
    }
}