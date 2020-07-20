using System;

namespace MeetingRoom.CommandHandler.Commands.Scheduler.Base
{
    public class SchedulerCommand
    {
        public string Observation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Responsible { get; set; }
        public Guid IdRoom { get; set; }
    }
}
