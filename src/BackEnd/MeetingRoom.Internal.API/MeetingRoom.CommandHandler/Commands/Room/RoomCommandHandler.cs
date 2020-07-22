using AutoMapper;
using MediatR;
using MeetingRoom.CommandHandler.Commands.Base;
using MeetingRoom.CommandHandler.Commands.Room.Add;
using MeetingRoom.CommandHandler.Commands.Room.Delete;
using MeetingRoom.CommandHandler.Commands.Room.Update;
using MeetingRoom.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace MeetingRoom.CommandHandler.Commands.Room
{
    public class RoomCommandHandler : BaseCommandHandler,
        IRequestHandler<AddRoomCommand, AddRoomResponse>,
        IRequestHandler<UpdateRoomCommand, Unit>,
        IRequestHandler<DeleteRoomCommand, Unit>
    {
        private readonly IRoomService _roomService;
        public RoomCommandHandler(
            IRoomService roomService,
            IMediator mediator,
            IMapper mapper) : base(mediator, mapper)
        {
            _roomService = roomService;
        }

        public async Task<AddRoomResponse> Handle(AddRoomCommand request, CancellationToken cancellationToken)
        {
            var room = _mapper.Map<Domain.Models.Room>(request);
            var response = await _roomService.AddRoomAsync(room);
            return new AddRoomResponse { Id = response };
        }

        public async Task<Unit> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            var room = _mapper.Map<Domain.Models.Room>(request);
            await _roomService.UpdateRoomAsync(room);
            return Unit.Value;
        }

        public async Task<Unit> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {
            await _roomService.DeleteRoomAsync(request.Id);
            return Unit.Value;
        }
    }
}
