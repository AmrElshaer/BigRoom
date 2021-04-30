using AutoMapper;
using AutoMapper.QueryableExtensions;
using BigRoom.Repository.Entities;
using BigRoom.Repository.IRepository;
using BigRoom.Service.DTO;
using BigRoom.Service.IService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigRoom.Service.Service
{
    public class DegreeService:IDegreeService
    {
        private readonly IQuizeRepository quizeRepository;
        private readonly IDegreeRepository degreeRepository;
        private readonly IMapper mapper;
        private readonly IUniteOfWork uniteOfWork;
        private readonly IHostingEnvironment ihostEnv;

        public DegreeService(IQuizeRepository quizeRepository,IDegreeRepository degreeRepository,IMapper mapper,IUniteOfWork uniteOfWork, IHostingEnvironment _IhostEnv)
        {
            this.quizeRepository = quizeRepository;
            this.degreeRepository = degreeRepository;
            this.mapper = mapper;
            this.uniteOfWork = uniteOfWork;
            ihostEnv = _IhostEnv;
        }
        public IEnumerable<DegreeDto> GetDegrees(int userId)
        {
            return  degreeRepository.GetAllAsync(a => a.UserProfileId == userId)
                .Include(a => a.Quize.Group).Select(mapper.Map<DegreeDto>);
        }
        public async Task CalCulateDegreeAsync(IList<string> answers,int quizeId,int userId)
        {
            var quize =await quizeRepository.GetByIdAsync(quizeId);
            var answerData = ReadAnswerfile(quize.Fileanswer);
            var degree=(answerData.Count()- answerData.Except(answers).Count());
            await  degreeRepository.AddAsync(new Degree() {ExamDegree=degree,QuizeId=quizeId,UserProfileId=userId,TotalDegree=answerData.Count });
            await uniteOfWork.SaveChangesAsync();
        }
        public IEnumerable<DegreeDto> GetQuizeDegrees(int quizeId)
        {
            return  degreeRepository.GetAllAsync(a=>a.QuizeId==quizeId).Include(u=>u.UserProfile)
                .Select(mapper.Map<DegreeDto>).ToList();
        }
        #region Read AnswerFile
        public IList<string> ReadAnswerfile(string filename)
        {
            var fullpath = Path.Combine(Path.Combine(ihostEnv.WebRootPath, "answer"), filename);
            List<string> answers = new List<string>();
            using (var reader = new StreamReader(fullpath))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line != null)
                    {
                        answers.Add(line);
                    }
                }

            }
            return answers;
        }


        #endregion
        public async Task<bool> IsDoExamAsync(int id, int userId)
        {
            return await degreeRepository.IsDoExamAsync(id,userId);
        }
    }
}
