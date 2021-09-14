using BigRoom.Repository.Entities;
using BigRoom.Service.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BigRoom.Service.IService
{
    public  interface IDegreeService : IServiceAsync<Degree, DegreeDto>
    {
        IEnumerable<DegreeDto> GetDegrees(int userId);
        Task CalCulateDegreeAsync(IList<string> answers, IList<string> answerData, int quizeId, int userId);
        IEnumerable<DegreeDto> GetQuizeDegrees(int quizeId);
    }
}
