using MeetingRoom.Infra.Data.Query.Queries.Scheduler;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeetingRoom.Infra.Data.Query.Interfaces
{
    public interface ISchedulerRepository
    {
        Task<IEnumerable<GetSchedulerQueryResponse>> GetAsync(Guid? id);
    }
}
