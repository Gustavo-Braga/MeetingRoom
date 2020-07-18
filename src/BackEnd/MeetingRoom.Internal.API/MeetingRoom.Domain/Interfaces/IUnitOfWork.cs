using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MeetingRoom.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        DbContext Context { get; }
        Task<int> CommitAsync();
    }
}
