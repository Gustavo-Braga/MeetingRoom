using MeetingRoom.Infra.Data.Query.Interfaces;
using MeetingRoom.Infra.Data.Query.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MeetingRoom.Internal.API.Ioc.DI
{
    public class RepositoriesQueryInection
    {
        public static void Inject(IServiceCollection services)
        {
            services.AddScoped<ISchedulerRepository, SchedulerRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
        }
    }
}
