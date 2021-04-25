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
    public class GroupService : IGroupService
    {
        private readonly IUniteOfWork uniteOfWork;
        private readonly IGroupRepository groupRepository;
        private readonly IMapper mapper;

        public GroupService(IUniteOfWork uniteOfWork,IGroupRepository groupRepository,IMapper mapper)
        {
            this.uniteOfWork = uniteOfWork;
            this.groupRepository = groupRepository;
            this.mapper = mapper;
        }

        public async Task CreateGroup(GroupDto group)
        {
            
            var entity = mapper.Map<Group>(group);
            await groupRepository.AddAsync(entity);
            await uniteOfWork.SaveChangesAsync();
        }
        public async Task<GroupDto> GetByIdAsync(int id)
        {
            return mapper.Map<GroupDto>(await groupRepository.GetByIdAsync(id));
        }
        public async Task UpdateGroup(GroupDto groupDto)
        {
            var group = mapper.Map<Group>(groupDto);
            await groupRepository.UpdateAsync(group);
            await uniteOfWork.SaveChangesAsync();
        }
        public async Task DeleteGroup(int groupId)
        {
            var group =await groupRepository.GetByIdAsync(groupId);
            await groupRepository.DeleteAsync(group);
            await uniteOfWork.SaveChangesAsync();
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
