using MediatR;
using MeetingRoom.Infra.Data.Query.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MeetingRoom.Infra.Data.Query.Queries.Scheduler
{
    public class SchedulerQueryHandler : IRequestHandler<GetSchedulerQuery, IEnumerable<GetSchedulerQueryResponse>>
    {
        private readonly ISchedulerRepository _schedulerRepository;

        public SchedulerQueryHandler(ISchedulerRepository schedulerRepository)
        {
            _schedulerRepository = schedulerRepository;
        }

        public async Task<IEnumerable<GetSchedulerQueryResponse>> Handle(GetSchedulerQuery request, CancellationToken cancellationToken)
        {
            return await _schedulerRepository.GetAsync(request.Id != default ? request.Id : default(Guid?));
        }
    }
}
