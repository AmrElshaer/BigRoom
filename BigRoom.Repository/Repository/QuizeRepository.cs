using BigRoom.Repository.Entities;
using BigRoom.Repository.Contexts;
using BigRoom.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigRoom.Repository.Repository
{
    public class QuizeRepository:RepositoryAsync<Quize>, IQuizeRepository
    {
        public QuizeRepository(BigRoomDbContext dbContext):base(dbContext)
        {

        }
    }
}
