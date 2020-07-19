using MediatR;
using MeetingRoom.CommandHandler.Commands.Room.Add;
using MeetingRoom.CrossCutting.Notification.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MeetingRoom.Internal.API.Controllers
{
    [ApiController]
    [Route("api/v1/rooms")]
    public class RoomController : ApiBaseController
    {
        public RoomController(IMediator mediator, INotificationContext notificationContext) 
            : base(mediator, notificationContext)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddRoomCommand request)
        {
            return await CreateResponse(async () => await _mediator.Send(request));
        }
    }
}