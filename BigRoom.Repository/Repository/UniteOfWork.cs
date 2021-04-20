using BigRoom.Repository.Contexts;
using BigRoom.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BigRoom.Repository.Repository
{
    public class UniteOfWork: IUniteOfWork
    {
        private readonly BigRoomDbContext _dbContext;

        public UniteOfWork(BigRoomDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
