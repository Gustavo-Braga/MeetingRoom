using System;

namespace MeetingRoom.Infra.Data.Query.Entities
{
    public class RoomScheduler
    {
        public Guid IdRoom { get; set; }
        public Guid IdScheduler { get; set; }
        public Room Room { get; set; }
        public Scheduler Scheduler { get; set; }
    }
}
