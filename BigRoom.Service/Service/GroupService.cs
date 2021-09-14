using AutoMapper;
using BigRoom.Repository.Entities;
using BigRoom.Repository.IRepository;
using BigRoom.Service.DTO;
using BigRoom.Service.IService;
using System.Threading.Tasks;
using BigRoom.Repository.Repository.Extensions;
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

        public bool IsUniqueName(string name)
        {
            if (string.IsNullOrEmpty(name)) return true;
            return groupRepository.UniquesNameAsync(name).GetAwaiter().GetResult();
        }

        public async Task<GroupDto> GetGroupByCodeAsync(string codeJoin)
        {
            return mapper.Map<GroupDto>(await groupRepository.GetGroupByCodeAsync(codeJoin));
        }

        public async Task<GroupDto> GroupDetailsByIdAsync(int id)
        {
            return mapper.Map<GroupDto>(await groupRepository.GroupDetailsByIdAsync(id));
        }
    }
}