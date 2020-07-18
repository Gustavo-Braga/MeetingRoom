using MeetingRoom.Domain.Interfaces;
using MeetingRoom.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MeetingRoom.Internal.API.Ioc.DI
{
    public static class ServicesInjection
    {
        public static void Inject(IServiceCollection services)
        {
            services.AddScoped<IRoomService, RoomService>();
        }
    }
}
