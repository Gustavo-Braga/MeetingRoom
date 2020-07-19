using MediatR;
using MeetingRoom.Internal.API.Ioc.DI;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using MeetingRoom.CommandHandler.MapperProfiles;
using FluentValidation.AspNetCore;
using MeetingRoom.CommandHandler.Commands.Room.Add;

namespace MeetingRoom.Internal.API.Ioc
{
    public static class Bootstrapper
    {
        public static void Initialize(IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup));
            services.AddAutoMapper(typeof(AutoMapping));
            services.AddMvc()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddRoomCommandValidator>());

            CommandsInjection.Inject(services);
            RepositoriesInjection.Inject(services);
            ServicesInjection.Inject(services);
            CrossCuttingInjection.Inject(services);
        }
    }
}
