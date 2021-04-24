using AutoMapper;
using BigRoom.Model.Entities;
using BigRoom.Repository.IRepository;
using BigRoom.Service.DTO;
using BigRoom.Service.IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BigRoom.Service.Service
{
    public class UserGroupService : IUserGroupService
    {
        private readonly IGroupRepository groupRepository;
        private readonly IUserGroupRepository userGroupRepository;
        private readonly IUniteOfWork uniteOfWork;
        private readonly IMapper mapper;

        public UserGroupService(IGroupRepository groupRepository,IUserGroupRepository userGroupRepository,IUniteOfWork uniteOfWork,IMapper mapper)
        {
            this.groupRepository = groupRepository;
            this.userGroupRepository = userGroupRepository;
            this.uniteOfWork = uniteOfWork;
            this.mapper = mapper;
        }

        public async Task CreateUserGroup(UserGroupsDto userGroupsDto)
        {
            await  userGroupRepository.AddAsync(mapper.Map<UserGroups>(userGroupsDto));
            await uniteOfWork.SaveChangesAsync();
        }

        public bool IsExist(string codeJoin)
        {
            return groupRepository.IsExistAsync(codeJoin).GetAwaiter().GetResult();
        }
        public bool UserIsJoinGroup(int groupId,int userId)
        {
           return userGroupRepository.UserIsJoinGroup(groupId,userId).GetAwaiter().GetResult();
        }
       

        public async Task LeaveGroupAsync(int id)
        {
            var userGroup = await userGroupRepository.GetByIdAsync(id)??throw  new Exception();
            await userGroupRepository.DeleteAsync(userGroup);
            await this.uniteOfWork.SaveChangesAsync();
        }
    }
}
