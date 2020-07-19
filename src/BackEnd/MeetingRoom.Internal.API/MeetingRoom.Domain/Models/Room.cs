using System;

namespace MeetingRoom.Domain.Models
{
    public class Room: EntitieBase<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
