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
            try
            {
                var room = _mapper.Map<Domain.Models.Room>(request);
                var response = await _roomService.AddRoomAsync(room);
                return new AddRoomResponse { Id = response };
            }
            catch (Exception ex)
            {
                var a = ex;
                //notification
                throw;
            }

        }
    }
}
