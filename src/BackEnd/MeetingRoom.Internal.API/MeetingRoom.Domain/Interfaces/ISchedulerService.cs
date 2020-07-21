using MeetingRoom.Domain.DTO;
using MeetingRoom.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeetingRoom.Domain.Interfaces
{
    public interface ISchedulerService
    {
        Task<Guid> AddSchedulerAsync(Scheduler request);
        Task<bool> UpdateSchedulerAsync(Scheduler request);
        Task<bool> DeleteSchedulerAsync(Guid id);
        Task<List<ConflictsRoom>> GetConflictsRoom(Scheduler request);
    }
}
