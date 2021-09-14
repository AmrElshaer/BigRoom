using AutoMapper;
using AutoMapper.QueryableExtensions;
using BigRoom.Repository.Entities;
using BigRoom.Repository.IRepository;
using BigRoom.Service.DTO;
using BigRoom.Service.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigRoom.Service.Service
{
    public class GroupPermissionService : IGroupPermissionService
    {
        private readonly IMapper mapper;
        private readonly IGroupPermissionRepository groupPermissionRepository;
        private readonly IUniteOfWork uniteOfWork;

        public GroupPermissionService(IMapper mapper,IGroupPermissionRepository groupPermissionRepository,IUniteOfWork uniteOfWork)
        {
            this.mapper = mapper;
            this.groupPermissionRepository = groupPermissionRepository;
            this.uniteOfWork = uniteOfWork;
        }
        public  IEnumerable<GroupPermissionDto> GetGroupPermissions(int groupId)
        {
            return  groupPermissionRepository.GetAll(a => a.GroupId == groupId).Include(a=>a.Group).Include(a=>a.UserProfile.ApplicationUser)
                .Include(a=>a.Quize).Select(mapper.Map<GroupPermissionDto>).ToList();
        }
        public async Task CreateEditAsync(GroupPermissionDto groupPermissionDto)
        {
            var groupPerm = mapper.Map<GroupPermission>(groupPermissionDto);
            if (groupPermissionDto.Id==0)
            {
              await  groupPermissionRepository.AddAsync(groupPerm);
            }
            else
            {
                await groupPermissionRepository.UpdateAsync(groupPerm);
            }
            await uniteOfWork.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var permission =await groupPermissionRepository.GetByIdAsync(id) ?? throw new Exception();
            await groupPermissionRepository.DeleteAsync(permission);
            await uniteOfWork.SaveChangesAsync();
        }
        public async Task<GroupPermissionDto> GetGroupPermissionById(int id)
        {
            return  mapper.Map<GroupPermissionDto>(await groupPermissionRepository.GetByIdAsync(id));
        }
    }
}
