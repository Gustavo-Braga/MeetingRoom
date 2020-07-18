using MeetingRoom.Domain.Models;
using System;
using System.Threading.Tasks;

namespace MeetingRoom.Domain.Interfaces
{
    public interface IRoomService
    {
        Task<Guid> AddRoom(Room room);
    }
}
