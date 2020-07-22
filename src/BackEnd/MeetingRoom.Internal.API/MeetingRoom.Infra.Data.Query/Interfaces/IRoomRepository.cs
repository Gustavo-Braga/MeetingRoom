using MeetingRoom.Infra.Data.Query.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeetingRoom.Infra.Data.Query.Interfaces
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAsync(Func<Room, bool> predicate);
    }
}
