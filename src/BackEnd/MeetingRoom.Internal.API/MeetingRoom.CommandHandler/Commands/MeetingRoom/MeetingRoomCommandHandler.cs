using MediatR;
using MeetingRoom.CommandHandler.Commands.Base;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MeetingRoom.CommandHandler.Commands.MeetingRoom
{
    public class MeetingRoomCommandHandler : BaseCommandHandler, IRequestHandler<AddMeetingRoomCommand, AddMeetingRoomResponse>
    {
        public MeetingRoomCommandHandler(IMediator mediator) : base(mediator)
        {
        }

        public async Task<AddMeetingRoomResponse> Handle(AddMeetingRoomCommand request, CancellationToken cancellationToken)
        {
            return new AddMeetingRoomResponse { Id = new Guid()};
        }
    }
}
