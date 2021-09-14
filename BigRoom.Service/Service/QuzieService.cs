using AutoMapper;
using AutoMapper.QueryableExtensions;
using BigRoom.Repository.Entities;
using BigRoom.Repository.IRepository;
using BigRoom.Service.Common.Models;
using BigRoom.Service.DTO;
using BigRoom.Service.IService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BigRoom.Service.Service
{
    public class QuzieService : IQuzieService
    {
        private readonly IQuizeRepository quizeRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IMapper mapper;
        private readonly IUniteOfWork uniteOfWork;

        public QuzieService(IQuizeRepository quizeRepository, IHostingEnvironment hostingEnvironment, IMapper mapper,
            IUniteOfWork uniteOfWork)
        {
            this.quizeRepository = quizeRepository;
            this.hostingEnvironment = hostingEnvironment;
            this.mapper = mapper;
            this.uniteOfWork = uniteOfWork;
        }

        public IEnumerable<QuizeDto> GetQuziesByGroup(int groupId)
        {
            return  quizeRepository.GetAllAsync(a => a.GroupId == groupId).Include(a=>a.GroupPermissions)
                .Select(mapper.Map<QuizeDto>).ToList();
        }
        public async Task CreateQuizeAsync(QuizeDto quizeDto)
        {
            quizeDto.File=await AddFileAsync(quizeDto.FileQuestion,"quize");
            quizeDto.Fileanswer= await AddFileAsync(quizeDto.FileAnswerForm, "answer");
            await quizeRepository.AddAsync(mapper.Map<Quize>(quizeDto));
            await uniteOfWork.SaveChangesAsync();
        }
       
        #region Add File
        async Task<string> AddFileAsync(IFormFile file, string path)
        {
            try
            {
                string webRootPath = hostingEnvironment.WebRootPath;
                // Generate Random name.
                string name = Guid.NewGuid().ToString().Substring(0, 8) + file.FileName;
                // Build the full path inclunding the file name
                string questionFilePath = Path.Combine(Path.Combine(webRootPath, path), name);
                #region Copy contents to memory stream.
                Stream stream;
                stream = new MemoryStream();
                file.CopyTo(stream);
                stream.Position = 0;
                #endregion
                #region Copy contents to folder
                using (FileStream writerFileStream = System.IO.File.Create(questionFilePath))
                {
                    await stream.CopyToAsync(writerFileStream);
                    writerFileStream.Dispose();
                }
                #endregion
                return name;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #region Remove File
        public void RemoveFile(string fileName,string folderName)
        {
            string webRootPath = hostingEnvironment.WebRootPath;
            string filePath =Path.Combine( Path.Combine(webRootPath, folderName),fileName);
            System.IO.File.Delete(filePath);
        }
        #endregion
        #region Read Question File
        private async Task<IEnumerable<QuestionModel>> ReaderQuestionsAsync(string csvFilePath)
        {
            var questions = new List<QuestionModel>();
            using (var reader = new StreamReader(csvFilePath))
            {
                while (!reader.EndOfStream)
                {
                    var resuilt = await reader.ReadLineAsync();
                    if (resuilt is null) continue;
                    var line = resuilt.Trim().Split(",");
                    var question = new QuestionModel(line[0], line.Skip(1).ToList());
                    questions.Add(question);
                }
            }
            return questions;
        }
        #endregion

        public async Task<QuizeDto> GetQuizeByIdAsync(int id)
        {
            var quize = await quizeRepository.GetByIdAsync(id);
            return mapper.Map<QuizeDto>(quize);

        }

        public async Task<QuizeModel> GetQuizeDetailsAsync(int id)
        {
            var quize = await GetQuizeByIdAsync(id);
            var path = Path.Combine(Path.Combine(hostingEnvironment.WebRootPath, "quize"), quize.File);
            var questions = await ReaderQuestionsAsync(path);
            return new QuizeModel(questions,quize);
        }
        public async Task DeleteAsync(int id)
        {
            var quize = await quizeRepository.GetByIdAsync(id);
            RemoveFile(quize.Fileanswer,"answer");
            RemoveFile(quize.File,"quize");
            await quizeRepository.DeleteAsync(quize);
            await uniteOfWork.SaveChangesAsync();
        }
        public async Task UpdateQuizeAsync(QuizeDto quizeDto)
        {
            if (quizeDto.FileQuestion!=null)
            {
                RemoveFile(quizeDto.File, "quize");
                quizeDto.File= await AddFileAsync(quizeDto.FileQuestion, "quize");
            }
            if (quizeDto.FileAnswerForm != null)
            {
                RemoveFile(quizeDto.Fileanswer,"answer");
                quizeDto.Fileanswer=await AddFileAsync(quizeDto.FileAnswerForm, "answer");
            }
            await quizeRepository.UpdateAsync(mapper.Map<Quize>(quizeDto));
            await uniteOfWork.SaveChangesAsync();
        }
    }
}