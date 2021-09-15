using AutoMapper;
using BigRoom.Repository.Entities;
using BigRoom.Repository.IRepository;
using BigRoom.Service.DTO;
using BigRoom.Service.IService;
using BigRoom.Service.UOW;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigRoom.Service.Service
{
    public class DegreeService : ServiceAsync<Degree, DegreeDto>, IDegreeService
    {
        private readonly IRepositoryAsync<Degree> degreeRepository;
        private readonly IMapper mapper;
        private readonly IUniteOfWork uniteOfWork;

        public DegreeService(IRepositoryAsync<Degree> degreeRepository,
            IMapper mapper, IUniteOfWork uniteOfWork)
            : base(degreeRepository, mapper)
        {
            this.degreeRepository = degreeRepository;
            this.mapper = mapper;
            this.uniteOfWork = uniteOfWork;
        }

        public IEnumerable<DegreeDto> GetDegrees(int userId)
        {
            return degreeRepository.GetAll(a => a.UserProfileId == userId)
                .Include(a => a.Quize.Group).Select(mapper.Map<DegreeDto>);
        }

        public async Task CalCulateDegreeAsync(IList<string> answers, IList<string> answerData, int quizeId, int userId)
        {
            var degree = (answerData.Count() - answerData.Except(answers).Count());
            await AddAsync(new DegreeDto()
            { ExamDegree = degree, QuizeId = quizeId, UserProfileId = userId, TotalDegree = answerData.Count });
            await uniteOfWork.SaveChangesAsync();
        }

        public IEnumerable<DegreeDto> GetQuizeDegrees(int quizeId)
        {
            return degreeRepository.GetAll(a => a.QuizeId == quizeId).Include(u => u.UserProfile.ApplicationUser)
                .Select(mapper.Map<DegreeDto>).ToList();
        }
    }
}