using AutoMapper;
using BigRoom.Repository.Entities;
using BigRoom.Repository.IRepository;
using BigRoom.Service.DTO;
using BigRoom.Service.IService;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BigRoom.Service.Service
{
    public class UserGroupService : ServiceAsync<UserGroups, UserGroupsDto>, IUserGroupService

    {
        private readonly IRepositoryAsync<UserGroups> userGroupRepository;
        private readonly IMapper mapper;

        public UserGroupService(IRepositoryAsync<UserGroups> userGroupRepository, IMapper mapper)
            : base(userGroupRepository, mapper)
        {
            this.userGroupRepository = userGroupRepository;
            this.mapper = mapper;
        }

        public IEnumerable<UserGroupsDto> GetUserInGroup(int groupId)
        {
            return userGroupRepository.GetAll(a => a.GroupId == groupId).Include(a => a.UserProfile)
                .ThenInclude(a => a.ApplicationUser).Select(mapper.Map<UserGroupsDto>);
        }
    }
}