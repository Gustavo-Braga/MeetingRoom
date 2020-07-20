using MediatR;
using MeetingRoom.CommandHandler.Commands.Scheduler.Base;
using System;
using System.Text.Json.Serialization;

namespace MeetingRoom.CommandHandler.Commands.Scheduler.Update
{
    public class UpdateSchedulerCommand: SchedulerCommand, IRequest<Unit>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
    }
}
