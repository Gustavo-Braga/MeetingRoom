﻿using MeetingRoom.Domain.Interfaces;
using MeetingRoom.Infra.Data.Command.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MeetingRoom.Internal.API.Ioc.DI
{
    public static class RepositoriesCommandInjection
    {
        public static void Inject(IServiceCollection services)
        {
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<ISchedulerRepository, SchedulerRepository>();
            services.AddScoped<IRoomSchedulerRepository, RoomSchedulerRepository>();

        }
    }
}
