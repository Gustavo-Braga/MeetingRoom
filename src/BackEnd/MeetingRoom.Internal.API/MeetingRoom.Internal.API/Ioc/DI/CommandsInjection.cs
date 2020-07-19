using MediatR;
using MeetingRoom.CommandHandler.Commands.Room;
using MeetingRoom.CommandHandler.Commands.Room.Add;
using MeetingRoom.CommandHandler.Commands.Room.Delete;
using MeetingRoom.CommandHandler.Commands.Room.Update;
using Microsoft.Extensions.DependencyInjection;

namespace MeetingRoom.Internal.API.Ioc.DI
{
    public static class CommandsInjection
    {
        public static void Inject(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AddRoomCommand, AddRoomResponse>, RoomCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateRoomCommand, Unit>, RoomCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteRoomCommand, Unit>, RoomCommandHandler>();
        }
    }
}
