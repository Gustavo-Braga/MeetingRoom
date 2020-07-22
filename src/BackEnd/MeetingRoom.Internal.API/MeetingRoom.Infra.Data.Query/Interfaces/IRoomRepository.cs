using MeetingRoom.Infra.Data.Query.Queries.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeetingRoom.Infra.Data.Query.Interfaces
{
    public interface IRoomRepository
    {
        Task<IEnumerable<RoomDto>> GetAsync(string name);
    }
}
