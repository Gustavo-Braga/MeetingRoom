using MeetingRoom.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeetingRoom.Domain.Interfaces
{
    public interface IRoomSchedulerRepository : IRepositoryBase<RoomScheduler>
    {
        Task AddRangeAsync(IEnumerable<RoomScheduler> entities);
        Task RemoveRange(IEnumerable<RoomScheduler> entities);
    }
}
