using AutoMapper;
using BigRoom.Repository.Entities;
using BigRoom.Repository.IRepository;
using BigRoom.Service.DTO;
using BigRoom.Service.File;
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
        private readonly IFileService fileService;
        private readonly IRepositoryAsync<Degree> degreeRepository;
        private readonly IRepositoryAsync<Quize> quizeRepository;
        private readonly IMapper mapper;
        private readonly IUniteOfWork uniteOfWork;

        public DegreeService(IFileService fileService, IRepositoryAsync<Degree> degreeRepository,
            IMapper mapper, IUniteOfWork uniteOfWork, IRepositoryAsync<Quize> quizeRepository)
            : base(degreeRepository, mapper)
        {
            this.fileService = fileService;
            this.degreeRepository = degreeRepository;
            this.mapper = mapper;
            this.uniteOfWork = uniteOfWork;
            this.quizeRepository = quizeRepository;
        }

        public IEnumerable<DegreeDto> GetDegrees(int userId)
        {
            return degreeRepository.GetAll(a => a.UserProfileId == userId)
                .Include(a => a.Quize.Group).Select(mapper.Map<DegreeDto>);
        }

        public async Task CalCulateDegreeAsync(IList<string> answers, int quizeId, int userId)
{
            var answerData = fileService.ReadAnswerfile((await quizeRepository.GetByIdAsync(quizeId)).Fileanswer);
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

        public async Task<bool> IsDoExam(int quizeId, int userId)
        {
            return (await GetFirstAsync(a => a.QuizeId == quizeId && a.UserProfileId == userId)) != null;
        }
    }
}