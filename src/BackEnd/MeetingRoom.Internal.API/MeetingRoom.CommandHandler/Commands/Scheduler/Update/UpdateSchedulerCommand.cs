using MediatR;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MeetingRoom.CommandHandler.Commands.Scheduler.Update
{
    public class UpdateSchedulerCommand:  IRequest<UpdateSchedulerResponse>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IEnumerable<Guid> Rooms { get; set; }
    }
}
