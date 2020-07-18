using MediatR;
using MeetingRoom.CommandHandler.Commands.MeetingRoom;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MeetingRoom.Internal.API.Controllers
{
    [Route("api/v1/meetingrooms")]
    [ApiController]
    public class MeetingRoomController : ControllerBase
    {
        public readonly IMediator _mediator;

        public MeetingRoomController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddMeetingRoomCommand request)
        {
            return Ok(new { data = _mediator.Send(request), success = true });
        }
    }
}