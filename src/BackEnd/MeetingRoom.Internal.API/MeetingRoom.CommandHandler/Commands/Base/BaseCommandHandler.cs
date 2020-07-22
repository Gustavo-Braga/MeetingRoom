using AutoMapper;
using MediatR;

namespace MeetingRoom.CommandHandler.Commands.Base
{
    public class BaseCommandHandler
    {
        public readonly IMediator _mediator;
        public readonly IMapper _mapper;

        public BaseCommandHandler(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
    }
}
