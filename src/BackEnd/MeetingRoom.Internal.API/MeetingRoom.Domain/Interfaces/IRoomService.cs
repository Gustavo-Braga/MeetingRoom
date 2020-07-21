using MeetingRoom.Domain.Models;
using System;
using System.Threading.Tasks;

namespace MeetingRoom.Domain.Interfaces
{
    public interface IRoomService
    {
        Task<Guid> AddRoomAsync(Room request);
        Task<bool> UpdateRoomAsync(Room request);
        Task<bool> DeleteRoomAsync(Guid id);
    }
}
