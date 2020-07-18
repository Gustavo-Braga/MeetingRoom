using AutoMapper;
using MediatR;
using MeetingRoom.CommandHandler.Commands.Base;
using MeetingRoom.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MeetingRoom.CommandHandler.Commands.Room
{
    public class RoomCommandHandler : BaseCommandHandler, IRequestHandler<AddRoomCommand, AddRoomResponse>
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
            var teste_mapper = _mapper.Map<Domain.Models.Room>(request);
            var a = await _roomService.AddRoom(teste_mapper);
            return new AddRoomResponse { Id = new Guid()};
        }
    }
}
