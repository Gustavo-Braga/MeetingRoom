using MediatR;
using MeetingRoom.CommandHandler.Commands.Room.Add;
using MeetingRoom.CommandHandler.Commands.Room.Delete;
using MeetingRoom.CommandHandler.Commands.Room.Update;
using MeetingRoom.CrossCutting.Notification.Interfaces;
using MeetingRoom.Infra.Data.Query.Queries.Room;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpGet]
        public async Task<IActionResult> Get(string name)
        {
            return await CreateResponse(async () => await _mediator.Send(new GetRoomQuery(name)));
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddRoomCommand request)
        {
            return await CreateResponse(async () => await _mediator.Send(request));
        }

        [HttpPut]
        [Route("api/v1/rooms/{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateRoomCommand request)
        {
            request.Id = id;
            return await CreateResponse(async () => await _mediator.Send(request));
        }

        [HttpDelete]
        [Route("api/v1/rooms/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return await CreateResponse(async () => await _mediator.Send(new DeleteRoomCommand(id)));
        }
    }
}