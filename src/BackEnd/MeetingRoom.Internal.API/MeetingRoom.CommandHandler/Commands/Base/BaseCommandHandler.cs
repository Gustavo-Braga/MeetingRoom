using System;
using MediatR;

namespace MeetingRoom.CommandHandler.Commands.Base
{
    public class BaseCommandHandler
    {
        public readonly IMediator _mediator;

        public BaseCommandHandler(IMediator mediator)
        {
            _mediator = mediator ;
        }
    }
}
