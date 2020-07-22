using MeetingRoom.Infra.Data.Query.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeetingRoom.Infra.Data.Query.Interfaces
{
    public interface ISchedulerRepository
    {
        Task<IEnumerable<Scheduler>> GetAsync(Func<Scheduler, bool> predicate);
    }
}
