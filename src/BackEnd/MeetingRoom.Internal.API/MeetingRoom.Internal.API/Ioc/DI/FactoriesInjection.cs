using MeetingRoom.Domain.Factories;
using MeetingRoom.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MeetingRoom.Internal.API.Ioc.DI
{
    public static class FactoriesInjection
    {

        public static void Inject(IServiceCollection services)
        {
            services.AddScoped<IRoomSchedulerFactory, RoomSchedulerFactory>();
        }
        
    }
}
