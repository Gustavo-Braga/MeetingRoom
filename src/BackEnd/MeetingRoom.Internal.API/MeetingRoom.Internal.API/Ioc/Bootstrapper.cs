using MediatR;
using MeetingRoom.Internal.API.Ioc.DI;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using MeetingRoom.CommandHandler.MapperProfiles;

namespace MeetingRoom.Internal.API.Ioc
{
    public static class Bootstrapper
    {
        public static void Initialize(IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup));
            services.AddAutoMapper(typeof(AutoMapping));

            CommandsInjection.Inject(services);
            RepositoriesInjection.Inject(services);
            ServicesInjection.Inject(services);
        }
    }
}
