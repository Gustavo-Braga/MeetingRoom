using System;
using System.Collections.Generic;

namespace MeetingRoom.CommandHandler.Commands.Scheduler.Base
{
    public class SchedulerCommand
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public IEnumerable<Guid> Rooms { get; set; }
    }
}
