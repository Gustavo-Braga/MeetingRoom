using System;
using System.Collections.Generic;

namespace MeetingRoom.Domain.Models
{
    public class Scheduler : EntitieBase<Guid>
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<RoomScheduler> RoomSchedulers { get; set; }

        public bool DateIsValid => EndDate > StartDate;
    }
}
