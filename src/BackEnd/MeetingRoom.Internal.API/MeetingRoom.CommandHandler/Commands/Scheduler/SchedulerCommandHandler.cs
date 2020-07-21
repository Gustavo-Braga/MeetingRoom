using AutoMapper;
using MediatR;
using MeetingRoom.CommandHandler.Commands.Base;
using MeetingRoom.CommandHandler.Commands.Scheduler.Add;
using MeetingRoom.CommandHandler.Commands.Scheduler.Delete;
using MeetingRoom.CommandHandler.Commands.Scheduler.Update;
using MeetingRoom.CrossCutting.Notification;
using MeetingRoom.Domain.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MeetingRoom.CommandHandler.Commands.Scheduler
{
    public class SchedulerCommandHandler : BaseCommandHandler,
        IRequestHandler<AddSchedulerCommand, AddSchedulerResponse>,
        IRequestHandler<UpdateSchedulerCommand, UpdateSchedulerResponse>,
        IRequestHandler<DeleteSchedulerCommand, Unit>
    {

        private readonly ISchedulerService _schedulerService;

        public SchedulerCommandHandler(ISchedulerService schedulerService, IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
            _schedulerService = schedulerService;
        }

        public async Task<AddSchedulerResponse> Handle(AddSchedulerCommand request, CancellationToken cancellationToken)
        {
            var scheduler = _mapper.Map<Domain.Models.Scheduler>(request);
            if (scheduler.RoomIsDuplicated)
            {
                await _mediator.Publish(new Notification("AddSchedulerCommand", $"Há salas duplicadas nesta agenda."));
                return null;
            }

            var conflicts = await _schedulerService.GetConflictsRoom(scheduler);

            return !conflicts.Any()
                ? new AddSchedulerResponse { Id = await _schedulerService.AddSchedulerAsync(scheduler) }
                : new AddSchedulerResponse { ConflictsRooms = conflicts };
        }

        public async Task<UpdateSchedulerResponse> Handle(UpdateSchedulerCommand request, CancellationToken cancellationToken)
        {
            var scheduler = _mapper.Map<Domain.Models.Scheduler>(request);

            if(scheduler.RoomIsDuplicated)
            {
                await _mediator.Publish(new Notification("UpdateSchedulerCommand", $"Há salas duplicadas nesta agenda."));
                return null;
            }

            var conflicts = await _schedulerService.GetConflictsRoom(scheduler);

            var response = new UpdateSchedulerResponse() { Id = request.Id };

            if (!conflicts.Any())
                await _schedulerService.UpdateSchedulerAsync(scheduler);
            else
                response.ConflictsRooms = conflicts;

            return response;
        }

        public async Task<Unit> Handle(DeleteSchedulerCommand request, CancellationToken cancellationToken)
        {
            await _schedulerService.DeleteSchedulerAsync(request.Id);
            return Unit.Value;
        }
    }
}
