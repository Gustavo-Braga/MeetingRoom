using MeetingRoom.Infra.Data.Query.Queries.DTO;
using System;
using System.Collections.Generic;

namespace MeetingRoom.Infra.Data.Query.Queries.Scheduler
{
    public class GetSchedulerQueryResponse
    {
        public GetSchedulerQueryResponse()
        {
            Rooms = new List<RoomDto>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public IList<RoomDto> Rooms { get; set; }
    }
}
