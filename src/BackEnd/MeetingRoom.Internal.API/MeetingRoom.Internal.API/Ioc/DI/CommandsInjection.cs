using MediatR;
using MeetingRoom.CommandHandler.Commands.Room;
using MeetingRoom.CommandHandler.Commands.Room.Add;
using MeetingRoom.CommandHandler.Commands.Room.Delete;
using MeetingRoom.CommandHandler.Commands.Room.Update;
using MeetingRoom.CommandHandler.Commands.Scheduler;
using MeetingRoom.CommandHandler.Commands.Scheduler.Add;
using MeetingRoom.CommandHandler.Commands.Scheduler.Delete;
using MeetingRoom.CommandHandler.Commands.Scheduler.Update;
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

            services.AddScoped<IRequestHandler<AddSchedulerCommand, AddSchedulerResponse>, SchedulerCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateSchedulerCommand, UpdateSchedulerResponse>, SchedulerCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteSchedulerCommand, Unit>, SchedulerCommandHandler>();
        }
    }
}
