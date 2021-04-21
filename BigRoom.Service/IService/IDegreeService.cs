using BigRoom.Service.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BigRoom.Service.IService
{
    public  interface IDegreeService
    {
        Task<IEnumerable<DegreeDto>> GetDegreesAsync(int userId);
        Task  CalCulateDegreeAsync(IList<string> answers, int quizeId, int userId);
        Task<IEnumerable<DegreeDto>> GetQuizeDegreesAsync(int quizeId);
        Task<bool> IsDoExamAsync(int id, int userId);
    }
}
