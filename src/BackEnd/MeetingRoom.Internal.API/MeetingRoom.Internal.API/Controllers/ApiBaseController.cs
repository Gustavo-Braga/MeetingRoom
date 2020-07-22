using MediatR;
using MeetingRoom.CrossCutting.Notification.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MeetingRoom.Internal.API.Controllers
{
    public class ApiBaseController : ControllerBase
    {
        public readonly IMediator _mediator;
        public readonly INotificationContext _notificationContext;

        public ApiBaseController(IMediator mediator, INotificationContext notificationContext)
        {
            _mediator = mediator;
            _notificationContext = notificationContext;
        }

        protected async Task<IActionResult> CreateResponse<T>(Func<Task<T>> function)
        {
            try
            {
                var data = await function();
                return Response(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { data = default(Nullable), success = false, notifications = ex.Message });
            }
        }

        private new IActionResult Response(object data)
        {
            if (!_notificationContext.HasNotifications)
                return Ok(new { data, success = true });
            else
                return BadRequest(new { data = default(Nullable), success = false, notifications = _notificationContext.Notifications });
        }
    }
}
