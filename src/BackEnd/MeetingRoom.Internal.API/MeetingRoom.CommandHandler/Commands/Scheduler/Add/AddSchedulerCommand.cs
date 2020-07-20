using MediatR;
using MeetingRoom.CommandHandler.Commands.Scheduler.Base;

namespace MeetingRoom.CommandHandler.Commands.Scheduler.Add
{
    public class AddSchedulerCommand : SchedulerCommand, IRequest<AddSchedulerResponse> 
    {

    }
}
