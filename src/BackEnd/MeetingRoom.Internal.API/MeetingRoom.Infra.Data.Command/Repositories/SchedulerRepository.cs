using MeetingRoom.Domain.Interfaces;
using MeetingRoom.Domain.Models;
using MeetingRoom.Infra.Data.Command.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MeetingRoom.Infra.Data.Command.Repositories
{
    public class SchedulerRepository : RepositoryBase<Scheduler>, ISchedulerRepository
    {
        public SchedulerRepository(MeetingRoomDBContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Scheduler>> GetAsync(Func<Scheduler, bool> predicate)
        {
            return await Task.Run(() =>
            {
                return _dbSet.Include(scheduler => scheduler.RoomSchedulers)
                .ThenInclude(roomSchedulers => roomSchedulers.Room)
                .AsQueryable().Where(predicate).AsEnumerable();

            });
        }

        public override async Task<Scheduler> SingleOrDefault(Expression<Func<Scheduler, bool>> expression)
        {
            return await _dbSet
                .Include(scheduler => scheduler.RoomSchedulers)
                .ThenInclude(roomSchedulers => roomSchedulers.Room)
                .SingleOrDefaultAsync(expression);
        }
    }
}
