using AutoMapper;
using AutoMapper.QueryableExtensions;
using BigRoom.Repository.Entities;
using BigRoom.Repository.IRepository;
using BigRoom.Service.Common.Behavoir;
using BigRoom.Service.DTO;
using BigRoom.Service.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigRoom.Repository.Repository.Extensions;
namespace BigRoom.Service.Service
{
    public class UserGroupService : IUserGroupService
    {
        private readonly IRepositoryAsync<Group> groupRepository;
        private readonly IUserGroupRepository userGroupRepository;
        private readonly IUniteOfWork uniteOfWork;
        private readonly IMapper mapper;

        public UserGroupService(IRepositoryAsync<Group> groupRepository,IUserGroupRepository userGroupRepository,IUniteOfWork uniteOfWork,IMapper mapper)
        {
            this.groupRepository = groupRepository;
            this.userGroupRepository = userGroupRepository;
            this.uniteOfWork = uniteOfWork;
            this.mapper = mapper;
        }

        public async Task<int> CreateUserGroup(UserGroupsDto userGroupsDto)
        {
            var gorup= await  userGroupRepository.AddAsync(mapper.Map<UserGroups>(userGroupsDto));
            await uniteOfWork.SaveChangesAsync();
            return gorup.Id;
        }

        public bool IsExist(string codeJoin)
        {
            return groupRepository.IsExistAsync(codeJoin).GetAwaiter().GetResult();
        }
        public bool UserIsJoinGroup(int groupId,int userId)
        {
           return userGroupRepository.UserIsJoinGroup(groupId,userId).GetAwaiter().GetResult();
        }
        public async Task<IEnumerable<object>> GetUserInGroupAsync(int groupId)
        {
          return await  userGroupRepository.GetAll(a=>a.GroupId==groupId)
                .Select(a=>new {Id=a.UserProfileId,Name=a.UserProfile.ApplicationUser.UserName.GetNameFromEmail() }).ToListAsync();
        }

        public async Task LeaveGroupAsync(int id)
        {
            var userGroup = await userGroupRepository.GetByIdAsync(id)??throw  new Exception();
            await userGroupRepository.DeleteAsync(userGroup);
            await this.uniteOfWork.SaveChangesAsync();
        }
    }
}
