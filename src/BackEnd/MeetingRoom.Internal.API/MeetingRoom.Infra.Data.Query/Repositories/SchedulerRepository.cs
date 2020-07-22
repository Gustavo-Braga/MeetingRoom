using MeetingRoom.Infra.Data.Query.Context;
using MeetingRoom.Infra.Data.Query.Entities;
using MeetingRoom.Infra.Data.Query.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoom.Infra.Data.Query.Repositories
{
    public class SchedulerRepository : ISchedulerRepository
    {
        private readonly DbContext _dbContext;
        private DbSet<Scheduler> _dbSet;

        public SchedulerRepository(MeetingRoomQueryDBContex context)
        {
            _dbContext = context;
            _dbSet = context.Set<Scheduler>();
        }

        public async Task<IEnumerable<Scheduler>> GetAsync(Func<Scheduler, bool> predicate)
        {
            return await Task.Run(() =>
            {
                return _dbSet
                .Include(x=> x.RoomSchedulers)
                .ThenInclude(roomSchedulers => roomSchedulers.Scheduler)
                .AsQueryable()
                .Where(predicate)
                .AsEnumerable();
            });
        }
    }
}
