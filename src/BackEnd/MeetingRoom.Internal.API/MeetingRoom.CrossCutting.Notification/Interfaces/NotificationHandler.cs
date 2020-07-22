using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MeetingRoom.CrossCutting.Notification.Interfaces
{
    public class NotificationHandler : INotificationHandler<Notification>
    {
        private readonly INotificationContext _notificationContext;

        public NotificationHandler(INotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        public async Task Handle(Notification notification, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                _notificationContext.AddNotification(notification);

            });
        }
    }
}
