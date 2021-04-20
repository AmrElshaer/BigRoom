using BigRoom.Service.Common.Models;
using BigRoom.Service.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BigRoom.Service.IService
{
    public  interface IQuzieService
    {
        Task<IEnumerable<QuizeDto>> GetQuziesByGroupAsync(int groupId);
        Task<QuizeModel> GetQuizeDetailsAsync(int id);
        Task CreateQuizeAsync(QuizeDto quizeDto);
        Task UpdateQuizeAsync(QuizeDto quizeDto);
        Task<QuizeDto> GetQuizeByIdAsync(int id);
        Task DeleteAsync(int id);
    }
}
