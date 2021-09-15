using BigRoom.Repository.Contexts;
using System.Threading;
using System.Threading.Tasks;

namespace BigRoom.Service.UOW
{
    public class UniteOfWork : IUniteOfWork
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