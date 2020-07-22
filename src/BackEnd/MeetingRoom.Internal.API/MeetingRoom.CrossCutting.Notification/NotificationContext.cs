using FluentValidation.Results;
using MediatR;
using MeetingRoom.CrossCutting.Notification.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MeetingRoom.CrossCutting.Notification
{
    public class NotificationContext :  INotificationContext
    {
        private readonly List<Notification> _notifications;
        public IEnumerable<Notification> Notifications => _notifications;

        public NotificationContext()
        {
            _notifications = new List<Notification>();
        }

        public bool HasNotifications => _notifications.Any();

        public void AddNotification(Notification notification)
        {
            _notifications.Add(notification);
        }

        public void AddNotifications(ValidationResult validations)
        {
            foreach (var error in validations.Errors)
                _notifications.Add(new Notification(error.ErrorCode, error.ErrorMessage));
        }
    }
}
