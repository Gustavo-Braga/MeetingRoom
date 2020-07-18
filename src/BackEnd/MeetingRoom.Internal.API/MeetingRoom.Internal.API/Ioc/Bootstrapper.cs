using MediatR;
using MeetingRoom.Internal.API.Ioc.DI;
using Microsoft.Extensions.DependencyInjection;

namespace MeetingRoom.Internal.API.Ioc
{
    public static class Bootstrapper
    {
        public static void Initialize(IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup));

            CommandsInjection.Inject(services);
        }
    }
}
