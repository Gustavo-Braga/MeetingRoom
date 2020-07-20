using AutoMapper;
using MediatR;
using MeetingRoom.CommandHandler.Commands.Base;
using MeetingRoom.CommandHandler.Commands.Scheduler.Add;
using MeetingRoom.CommandHandler.Commands.Scheduler.Delete;
using MeetingRoom.CommandHandler.Commands.Scheduler.Update;
using MeetingRoom.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace MeetingRoom.CommandHandler.Commands.Scheduler
{
    public class SchedulerCommandHandler : BaseCommandHandler,
        IRequestHandler<AddSchedulerCommand, AddSchedulerResponse>,
        IRequestHandler<UpdateSchedulerCommand, Unit>,
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
            var response = await _schedulerService.AddSchedulerAsync(scheduler);
            return new AddSchedulerResponse { Id = response };
        }

        public async Task<Unit> Handle(UpdateSchedulerCommand request, CancellationToken cancellationToken)
        {
            var scheduler = _mapper.Map<Domain.Models.Scheduler>(request);
            await _schedulerService.UpdateSchedulerAsync(scheduler);
            return Unit.Value;
        }

        public async Task<Unit> Handle(DeleteSchedulerCommand request, CancellationToken cancellationToken)
        {
            await _schedulerService.DeleteSchedulerAsync(request.Id);
            return Unit.Value;
        }
    }
}
