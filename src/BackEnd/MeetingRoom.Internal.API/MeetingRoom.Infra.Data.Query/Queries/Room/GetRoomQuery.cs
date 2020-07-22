using MediatR;
using MeetingRoom.Infra.Data.Query.Queries.DTO;
using System.Collections.Generic;

namespace MeetingRoom.Infra.Data.Query.Queries.Room
{
    public class GetRoomQuery : IRequest<IEnumerable<RoomDto>>
    {
        public GetRoomQuery(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
