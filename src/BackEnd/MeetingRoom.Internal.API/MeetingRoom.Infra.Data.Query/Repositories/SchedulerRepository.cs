
using Dapper;
using MeetingRoom.Infra.Data.Query.Interfaces;
using MeetingRoom.Infra.Data.Query.Queries.DTO;
using MeetingRoom.Infra.Data.Query.Queries.Scheduler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoom.Infra.Data.Query.Repositories
{
    public class SchedulerRepository : ISchedulerRepository
    {
        private readonly IDbConnection _dbConnection;


        public SchedulerRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<GetSchedulerQueryResponse>> GetAsync(Guid? id)
        {
            var sql = "select s.Id, s.Title, s.StartDate, s.EndDate, r.Id, r.[Name], r.[Description] from Scheduler s " +
                       "inner join RoomScheduler rs on rs.IdScheduler = s.Id " +
                       "inner join Room r on r.Id = rs.IdRoom " +
                       "where @Id is null or @Id = s.Id";

            var response = new Dictionary<Guid, GetSchedulerQueryResponse>();

            var result = await _dbConnection.QueryAsync<GetSchedulerQueryResponse, RoomDto, GetSchedulerQueryResponse>(
                sql,
                (s, r) =>
                {
                    if (response.ContainsKey(s.Id))
                        response[s.Id].Rooms.Add(r);
                    else
                    {
                        s.Rooms.Add(r);
                        response.Add(s.Id, s);
                    }
                    return s;
                },
                param: new
                {
                    Id = id
                });

            return response.Values.ToList();
        }
    }
}
