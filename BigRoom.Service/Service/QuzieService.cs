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
        private readonly IFileService fileService;
        private readonly IRepositoryAsync<Quize> quizeRepository;

        public QuzieService(IFileService fileService,IRepositoryAsync<Quize> quizeRepository, IMapper mapper)
            : base(quizeRepository, mapper)
        {
            this.fileService = fileService;
            this.quizeRepository = quizeRepository;
            this.mapper = mapper;
        }

        public IEnumerable<QuizeDto> GetQuziesByGroup(int groupId)
        {
            return quizeRepository.GetAll(a => a.GroupId == groupId).Include(a => a.GroupPermissions)
                .Select(mapper.Map<QuizeDto>).ToList();
        }
        public async Task<QuizeModel> GenerateQuzie(int quizeId)
        {
            var quize = await GetByIdAsync(quizeId);
            var questions = await fileService.ReaderQuestionsAsync(quize.File);
            return new QuizeModel(questions, quize);
        }
        public async Task RemoveQuzie(int id)
        {
            var quize = await GetByIdAsync(id);
            fileService.RemoveFile(quize.Fileanswer, "answer");
            fileService.RemoveFile(quize.File, "quize");
            await DeleteAsync(id);
        }
        public async Task AddQuzieAsync(QuizeDto quize)
        {
            quize.File = await fileService.AddFileAsync(quize.FileQuestion, "quize");
            quize.Fileanswer = await fileService.AddFileAsync(quize.FileAnswerForm, "answer");
            await AddAsync(quize);
        }
        public async Task UpdateQuzieAsync(QuizeDto quize)
        {
            if (quize.FileQuestion != null)
            {
                fileService.RemoveFile(quize.File, "quize");
                quize.File = await fileService.AddFileAsync(quize.FileQuestion, "quize");
            }
            if (quize.FileAnswerForm != null)
            {
                fileService.RemoveFile(quize.Fileanswer, "answer");
                quize.Fileanswer = await fileService.AddFileAsync(quize.FileAnswerForm, "answer");
            }
            await UpdateAsync(quize);
        }
    }
}