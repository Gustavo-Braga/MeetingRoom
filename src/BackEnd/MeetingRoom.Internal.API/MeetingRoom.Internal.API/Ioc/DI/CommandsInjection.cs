using MediatR;
using MeetingRoom.CommandHandler.Commands.MeetingRoom;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoom.Internal.API.Ioc.DI
{
    public static class CommandsInjection
    {
        public static void Inject(IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<AddMeetingRoomCommand, AddMeetingRoomResponse>, MeetingRoomCommandHandler>();
        }
    }
}
