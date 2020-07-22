using MediatR;
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
            services.AddScoped<IRequestHandler<GetRoomQuery, IEnumerable<RoomDto>>, RoomQueryHandler>();
            services.AddScoped<IRequestHandler<GetSchedulerQuery, IEnumerable<GetSchedulerQueryResponse>>, SchedulerQueryHandler>();
        }
    }
}
