using MediatR;
using System;
using System.Collections.Generic;

namespace MeetingRoom.Infra.Data.Query.Queries.Scheduler
{
    public class GetSchedulerQuery: IRequest<IEnumerable<GetSchedulerQueryResponse>>
    {
        public GetSchedulerQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
