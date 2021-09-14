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
    public class UserGroupService :ServiceAsync<UserGroups,UserGroupsDto>, IUserGroupService

    {
        
        private readonly IRepositoryAsync<UserGroups> userGroupRepository;
        private readonly IMapper mapper;

        public UserGroupService(IUserGroupRepository userGroupRepository,
            IUniteOfWork uniteOfWork,IMapper mapper):base(uniteOfWork,userGroupRepository,mapper)
        {
            this.userGroupRepository = userGroupRepository;
            this.mapper = mapper;
        }
        public  IEnumerable<UserGroupsDto> GetUserInGroup(int groupId)
        {
          return   userGroupRepository.GetAll(a=>a.GroupId==groupId).Include(a=>a.UserProfile).ThenInclude(a=>a.ApplicationUser).Select(mapper.Map<UserGroupsDto>);
        }

        
    }
}
