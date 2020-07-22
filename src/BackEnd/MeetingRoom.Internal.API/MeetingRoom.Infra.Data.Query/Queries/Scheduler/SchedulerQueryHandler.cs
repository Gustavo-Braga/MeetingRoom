using AutoMapper;
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
            //var schedulers = await _schedulerRepository.GetAsync(x => request.Id != default(Guid) ? x.Id == request.Id : true);

            var response = new List<GetSchedulerQueryResponse>();
            //foreach (var item in schedulers)
            //{
            //    response

            //}


            return response;
        }
    }
}
