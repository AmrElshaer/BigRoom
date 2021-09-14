using AutoMapper;
using BigRoom.Repository.Entities;
using BigRoom.Repository.IRepository;
using BigRoom.Service.DTO;
using BigRoom.Service.IService;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BigRoom.Service.Service
{
    public class GroupService : ServiceAsync<Group, GroupDto>, IGroupService
    {
        private readonly IRepositoryAsync<Group> groupRepository;
        private readonly IMapper mapper;

        public GroupService(IUniteOfWork uniteOfWork, IRepositoryAsync<Group> groupRepository, IMapper mapper)
            : base(uniteOfWork, groupRepository, mapper)
        {
            this.groupRepository = groupRepository;
            this.mapper = mapper;
        }

        public async Task<GroupDto> GroupDetailsByIdAsync(int id)
        {
            return mapper.Map<GroupDto>(await groupRepository.Entities.Include(a => a.Groups).ThenInclude(a => a.UserProfile.ApplicationUser)
                .Include(a => a.GroupPermissions)
                .Include(a => a.Admin).FirstOrDefaultAsync(a => a.Id == id));
        }
    }
}