using System;

namespace MeetingRoom.Domain.DTO
{
    public class SchedulerConflict
    {
        public SchedulerConflict(Guid idScheduler, string title, DateTime startDate, DateTime endDate)
        {
            IdScheduler = idScheduler;
            Title = title;
            StartDate = startDate;
            EndDate = endDate;
        }

        public Guid IdScheduler { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
