using AutoMapper;
using BigRoom.Repository.Entities;
using BigRoom.Repository.IRepository;
using BigRoom.Service.Common.Models;
using BigRoom.Service.DTO;
using BigRoom.Service.File;
using BigRoom.Service.IService;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigRoom.Service.Service
{
    public class QuzieService : ServiceAsync<Quize, QuizeDto>, IQuzieService
    {
        
        private readonly IMapper mapper;
        private readonly IRepositoryAsync<Quize> quizeRepository;

        public QuzieService(IRepositoryAsync<Quize> quizeRepository, IMapper mapper,
            IUniteOfWork uniteOfWork) : base(uniteOfWork, quizeRepository, mapper)
        {
            this.quizeRepository = quizeRepository;
            this.mapper = mapper;
        }

        public IEnumerable<QuizeDto> GetQuziesByGroup(int groupId)
        {
            return quizeRepository.GetAll(a => a.GroupId == groupId).Include(a => a.GroupPermissions)
                .Select(mapper.Map<QuizeDto>).ToList();
        }
      
    }
}