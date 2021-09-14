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
        private readonly IFileService fileService;
        private readonly IMapper mapper;
        private readonly IRepositoryAsync<Quize> quizeRepository;

        public QuzieService(IRepositoryAsync<Quize> quizeRepository, IFileService fileService, IMapper mapper,
            IUniteOfWork uniteOfWork) : base(uniteOfWork, quizeRepository, mapper)
        {
            this.quizeRepository = quizeRepository;
            this.fileService = fileService;
            this.mapper = mapper;
        }

        public async Task CreateQuizeAsync(QuizeDto quizeDto)
        {
            quizeDto.File = await fileService.AddFileAsync(quizeDto.FileQuestion, "quize");
            quizeDto.Fileanswer = await fileService.AddFileAsync(quizeDto.FileAnswerForm, "answer");
            await AddAsync(quizeDto);
        }

        public async Task DeleteQuzieAsync(int id)
        {
            var quize = await GetByIdAsync(id);
            fileService.RemoveFile(quize.Fileanswer, "answer");
            fileService.RemoveFile(quize.File, "quize");
            await DeleteQuzieAsync(id);
        }

        public async Task<QuizeModel> GetQuizeDetailsAsync(int id)
        {
            var quize = await GetByIdAsync(id);
            var questions = await fileService.ReaderQuestionsAsync(quize.File);
            return new QuizeModel(questions, quize);
        }

        public IEnumerable<QuizeDto> GetQuziesByGroup(int groupId)
        {
            return quizeRepository.GetAllAsync(a => a.GroupId == groupId).Include(a => a.GroupPermissions)
                .Select(mapper.Map<QuizeDto>).ToList();
        }

        public async Task UpdateQuizeAsync(QuizeDto quizeDto)
        {
            if (quizeDto.FileQuestion != null)
            {
                fileService.RemoveFile(quizeDto.File, "quize");
                quizeDto.File = await fileService.AddFileAsync(quizeDto.FileQuestion, "quize");
            }
            if (quizeDto.FileAnswerForm != null)
            {
                fileService.RemoveFile(quizeDto.Fileanswer, "answer");
                quizeDto.Fileanswer = await fileService.AddFileAsync(quizeDto.FileAnswerForm, "answer");
            }
            await UpdateAsync(quizeDto);
        }
    }
}