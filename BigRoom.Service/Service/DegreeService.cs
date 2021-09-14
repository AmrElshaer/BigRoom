using AutoMapper;
using BigRoom.Repository.Entities;
using BigRoom.Repository.IRepository;
using BigRoom.Repository.Repository.Extensions;
using BigRoom.Service.DTO;
using BigRoom.Service.File;
using BigRoom.Service.IService;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigRoom.Service.Service
{
    public class DegreeService : ServiceAsync<Degree, DegreeDto>, IDegreeService
    {
        private readonly IQuizeRepository quizeRepository;
        private readonly IRepositoryAsync<Degree> degreeRepository;
        private readonly IMapper mapper;
        private readonly IUniteOfWork uniteOfWork;
        private readonly IFileService fileService;

        public DegreeService(IQuizeRepository quizeRepository, IRepositoryAsync<Degree> degreeRepository,
            IMapper mapper, IUniteOfWork uniteOfWork, IFileService fileService)
            : base(uniteOfWork, degreeRepository, mapper)
        {
            this.quizeRepository = quizeRepository;
            this.degreeRepository = degreeRepository;
            this.mapper = mapper;
            this.uniteOfWork = uniteOfWork;
            this.fileService = fileService;
        }

        public IEnumerable<DegreeDto> GetDegrees(int userId)
        {
            return degreeRepository.GetDegrees(userId).Select(mapper.Map<DegreeDto>);
        }

        public async Task CalCulateDegreeAsync(IList<string> answers, int quizeId, int userId)
        {
            var answerData = fileService.ReadAnswerfile((await quizeRepository.GetByIdAsync(quizeId)).Fileanswer);
            var degree = (answerData.Count() - answerData.Except(answers).Count());
            await degreeRepository.AddAsync(new Degree()
            { ExamDegree = degree, QuizeId = quizeId, UserProfileId = userId, TotalDegree = answerData.Count });
            await uniteOfWork.SaveChangesAsync();
        }

        public IEnumerable<DegreeDto> GetQuizeDegrees(int quizeId)
        {
            return degreeRepository.GetQuizeDegrees(quizeId).Select(mapper.Map<DegreeDto>).ToList();
        }

        public async Task<bool> IsDoExamAsync(int id, int userId)
        {
            return await degreeRepository.IsDoExamAsync(id, userId);
        }
    }
}