using MediatR;
using MeetingRoom.CrossCutting.Notification;
using MeetingRoom.CrossCutting.Notification.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MeetingRoom.Internal.API.Ioc.DI
{
    public class CrossCuttingInjection
    {
        public static void Inject(IServiceCollection services)
        {
            services.AddScoped<INotificationContext, NotificationContext>();
            services.AddScoped<INotificationHandler<Notification>, NotificationHandler>();
            services.AddScoped<INotification, Notification>();
        }
    }
}
