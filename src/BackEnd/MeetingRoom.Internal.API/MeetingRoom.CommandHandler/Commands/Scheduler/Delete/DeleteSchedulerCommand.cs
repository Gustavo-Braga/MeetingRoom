using MediatR;
using System;

namespace MeetingRoom.CommandHandler.Commands.Scheduler.Delete
{
    public class DeleteSchedulerCommand : IRequest<Unit>
    {
        public DeleteSchedulerCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }

}
