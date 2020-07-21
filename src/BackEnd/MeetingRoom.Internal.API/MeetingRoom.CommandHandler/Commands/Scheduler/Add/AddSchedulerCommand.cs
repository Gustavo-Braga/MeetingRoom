using MediatR;
using System;
using System.Collections.Generic;

namespace MeetingRoom.CommandHandler.Commands.Scheduler.Add
{
    public class AddSchedulerCommand : IRequest<AddSchedulerResponse>
    {

        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public IEnumerable<Guid> Rooms { get; set; }
    }
}
