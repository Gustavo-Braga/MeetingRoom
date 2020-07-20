using System;

namespace MeetingRoom.Domain.Models
{
    public class Scheduler : EntitieBase<Guid>
    {
        public string Observation { get; set; }
        public Guid IdRoom { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Responsible { get; set; }
        public Room Room { get; set; }

        public bool DateIsValid => EndDate > StartDate;
    }
}
