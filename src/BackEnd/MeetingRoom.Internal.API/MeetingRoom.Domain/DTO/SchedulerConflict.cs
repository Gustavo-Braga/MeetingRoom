using System;

namespace MeetingRoom.Domain.DTO
{
    public class SchedulerConflict
    {
        public Guid IdScheduler { get; set; }
        public string Title { get; set; }
        public DateTime StartConflictDate { get; set; }
        public DateTime EndConflictDate { get; set; }
    }
}
