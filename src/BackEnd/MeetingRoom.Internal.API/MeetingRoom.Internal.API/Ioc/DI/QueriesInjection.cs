using AutoMapper;
using MediatR;
using MeetingRoom.Infra.Data.Query.MapperProfile;
using MeetingRoom.Infra.Data.Query.Queries.DTO;
using MeetingRoom.Infra.Data.Query.Queries.Room;
using MeetingRoom.Infra.Data.Query.Queries.Scheduler;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace MeetingRoom.Internal.API.Ioc.DI
{
    public class QueriesInjection
    {
        public static void Inject(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapping));

            services.AddScoped<IRequestHandler<GetRoomQuery, IEnumerable<RoomDto>>, RoomQueryHandler>();
            services.AddScoped<IRequestHandler<GetSchedulerQuery, IEnumerable<GetSchedulerQueryResponse>>, SchedulerQueryHandler>();
        }
    }
}
