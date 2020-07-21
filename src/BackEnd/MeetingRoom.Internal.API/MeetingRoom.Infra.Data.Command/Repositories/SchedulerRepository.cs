using MeetingRoom.Domain.Interfaces;
using MeetingRoom.Domain.Models;
using MeetingRoom.Infra.Data.Command.Context;

namespace MeetingRoom.Infra.Data.Command.Repositories
{
    public class SchedulerRepository : RepositoryBase<Scheduler>, ISchedulerRepository
    {
        public SchedulerRepository(MeetingRoomDBContext context) : base(context)
        {
        }
    }
}
