using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MeetingRoom.CommandHandler.Commands.Scheduler.Add;
using MeetingRoom.CommandHandler.Commands.Scheduler.Delete;
using MeetingRoom.CommandHandler.Commands.Scheduler.Update;
using MeetingRoom.CrossCutting.Notification.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetingRoom.Internal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulerController : ApiBaseController
    {
        public SchedulerController(IMediator mediator, INotificationContext notificationContext) : base(mediator, notificationContext)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddSchedulerCommand request)
        {
            return await CreateResponse(async () => await _mediator.Send(request));
        }

        [HttpPut]
        [Route("api/v1/schedulers/{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateSchedulerCommand request)
        {
            request.Id = id;
            return await CreateResponse(async () => await _mediator.Send(request));
        }

        [HttpDelete]
        [Route("api/v1/schedulers/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return await CreateResponse(async () => await _mediator.Send(new DeleteSchedulerCommand(id)));
        }
    }
}