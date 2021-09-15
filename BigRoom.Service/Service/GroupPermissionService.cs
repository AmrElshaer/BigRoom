using AutoMapper;
using BigRoom.Repository.Entities;
using BigRoom.Repository.IRepository;
using BigRoom.Service.DTO;
using BigRoom.Service.IService;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigRoom.Service.Service
{
    public class GroupPermissionService : ServiceAsync<GroupPermission, GroupPermissionDto>, IGroupPermissionService
    {
        private readonly IMapper mapper;
        private readonly IRepositoryAsync<GroupPermission> groupPermissionRepository;

        public GroupPermissionService(IMapper mapper, IRepositoryAsync<GroupPermission> groupPermissionRepository
            ) : base(groupPermissionRepository, mapper)
        {
            this.mapper = mapper;
            this.groupPermissionRepository = groupPermissionRepository;
        }

        public IEnumerable<GroupPermissionDto> GetGroupPermissions(int groupId)
        {
            return groupPermissionRepository.GetAll(a => a.GroupId == groupId).Include(a => a.Group)
                .Include(a => a.UserProfile.ApplicationUser)
                .Include(a => a.Quize).Select(mapper.Map<GroupPermissionDto>).ToList();
        }
     
    }
}