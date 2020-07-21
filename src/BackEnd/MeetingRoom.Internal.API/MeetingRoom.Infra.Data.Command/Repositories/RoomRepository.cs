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
    public class RoomRepository : RepositoryBase<Room>, IRoomRepository
    {
        public RoomRepository(MeetingRoomDBContext context) : base(context)
        {
        }


        public override async Task<IEnumerable<Room>> GetAsync(Func<Room, bool> predicate)
        {
            return await Task.Run(() =>
            {
                return _dbSet.Include(room => room.RoomSchedulers)
                .ThenInclude(roomSchedulers => roomSchedulers.Scheduler)
                .AsQueryable().Where(predicate).AsEnumerable();

            });
        }
    }
}
