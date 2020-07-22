using MeetingRoom.Domain.Interfaces;
using MeetingRoom.Domain.Models;
using MeetingRoom.Infra.Data.Command.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeetingRoom.Infra.Data.Command.Repositories
{
    public class RoomSchedulerRepository : RepositoryBase<RoomScheduler>, IRoomSchedulerRepository
    {
        public RoomSchedulerRepository(MeetingRoomDBContext context) : base(context)
        {
        }


        public async Task AddRangeAsync(IEnumerable<RoomScheduler> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task RemoveRange(IEnumerable<RoomScheduler> entities)
        {
            await Task.Run(() =>
            {
                _dbSet.RemoveRange(entities);
            });
        }
    }
}
