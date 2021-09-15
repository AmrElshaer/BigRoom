using System.Threading;
using System.Threading.Tasks;

namespace BigRoom.Service.UOW
{
    public interface IUniteOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}