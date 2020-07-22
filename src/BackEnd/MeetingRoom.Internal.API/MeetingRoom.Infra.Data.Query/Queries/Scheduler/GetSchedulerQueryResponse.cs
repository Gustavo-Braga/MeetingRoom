using MeetingRoom.Infra.Data.Query.Queries.DTO;
using System;
using System.Collections.Generic;

namespace MeetingRoom.Infra.Data.Query.Queries.Scheduler
{
    public class GetSchedulerQueryResponse
    {
        public GetSchedulerQueryResponse(Guid id, string title, IEnumerable<RoomDto> rooms)
        {
            Id = id;
            Title = title;
            Rooms = rooms;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<RoomDto> Rooms { get; set; }
    }
}
