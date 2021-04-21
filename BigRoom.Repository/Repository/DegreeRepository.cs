using BigRoom.Model.Entities;
using BigRoom.Repository.Contexts;
using BigRoom.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BigRoom.Repository.Repository
{
    public class DegreeRepository:RepositoryAsync<Degree>,IDegreeRepository
    {
        public DegreeRepository(BigRoomDbContext context):base(context)
        {

        }

        public async Task<bool> IsDoExamAsync(int id, int userId)
        {
            return (await Entities.FirstOrDefaultAsync(a=>a.QuizeId==id&&a.UserProfileId==userId))==null?false:true;
        }
    }
}
