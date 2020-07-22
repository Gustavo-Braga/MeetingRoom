using System;
using System.Collections.Generic;

namespace MeetingRoom.Infra.Data.Query.Entities
{
    public class Room : EntitieBase<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<RoomScheduler> RoomSchedulers { get; set; }
    }
}
