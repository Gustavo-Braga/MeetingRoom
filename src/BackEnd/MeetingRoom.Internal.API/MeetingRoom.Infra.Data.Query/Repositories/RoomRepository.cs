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
    public class RoomRepository : IRoomRepository
    {
        private readonly DbContext _dbContext;
        private DbSet<Room> _dbSet;

        public RoomRepository(MeetingRoomQueryDBContex context)
        {
            _dbContext = context;
            _dbSet = context.Set<Room>();
        }

        public async Task<IEnumerable<Room>> GetAsync(Func<Room, bool> predicate)
        {
            return await Task.Run(() =>
            {
                return _dbSet.AsQueryable().Where(predicate).AsEnumerable();

            });
        }

    }
}
