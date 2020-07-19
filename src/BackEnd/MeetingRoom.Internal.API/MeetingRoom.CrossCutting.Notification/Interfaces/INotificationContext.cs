using FluentValidation.Results;
using System.Collections.Generic;

namespace MeetingRoom.CrossCutting.Notification.Interfaces
{
    public interface INotificationContext
    {
        IEnumerable<Notification> Notifications { get; }
        bool HasNotifications { get; }
        void AddNotification(Notification notification);
        void AddNotifications(ValidationResult validations);
    }
}
