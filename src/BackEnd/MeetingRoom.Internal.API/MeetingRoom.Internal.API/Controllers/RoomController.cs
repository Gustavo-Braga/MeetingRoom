using MediatR;
using MeetingRoom.CommandHandler.Commands.Room;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MeetingRoom.Internal.API.Controllers
{
    [ApiController]
    [Route("api/v1/rooms")]
    public class RoomController : ControllerBase
    {
        public readonly IMediator _mediator;

        public RoomController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddRoomCommand request)
        {
            return Ok(new { data = await _mediator.Send(request), success = true });
        }
    }
}