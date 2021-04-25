using BigRoom.Service.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BigRoom.Service.IService
{
    public interface IGroupService
    {
       bool IsUniqueName(string name);
       Task CreateGroup(GroupDto group);
        Task<GroupDto> GetByIdAsync(int id);
        Task UpdateGroup(GroupDto groupDto);
        Task DeleteGroup(int groupId);
        Task<GroupDto> GetGroupByCodeAsync(string codeJoin);
        Task<GroupDto> GroupDetailsByIdAsync(int id);
    }
}
