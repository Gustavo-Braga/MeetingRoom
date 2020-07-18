using MeetingRoom.Domain.Interfaces;
using MeetingRoom.Infra.Data.Command.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MeetingRoom.Infra.Data.Command.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext Context => _meetingRoomDBContext;

        private readonly MeetingRoomDBContext _meetingRoomDBContext;

        public UnitOfWork(MeetingRoomDBContext context)
        {
            _meetingRoomDBContext = context;
        }

        public async Task<int> CommitAsync()
        {
            return await Context.SaveChangesAsync();
        }

    }
}
