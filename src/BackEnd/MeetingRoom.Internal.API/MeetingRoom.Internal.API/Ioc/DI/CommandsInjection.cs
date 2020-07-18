using MediatR;
using MeetingRoom.CommandHandler.Commands.Room;
using Microsoft.Extensions.DependencyInjection;

namespace MeetingRoom.Internal.API.Ioc.DI
{
    public static class CommandsInjection
    {
        public static void Inject(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AddRoomCommand, AddRoomResponse>, RoomCommandHandler>();
        }
    }
}
