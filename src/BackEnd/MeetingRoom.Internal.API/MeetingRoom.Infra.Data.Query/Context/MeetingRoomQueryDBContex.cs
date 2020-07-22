using MeetingRoom.Infra.Data.Query.Entities;
using MeetingRoom.Infra.Data.Query.Mapping;
using Microsoft.EntityFrameworkCore;

namespace MeetingRoom.Infra.Data.Query.Context
{
    public class MeetingRoomQueryDBContex : DbContext
    {
        public MeetingRoomQueryDBContex(DbContextOptions<MeetingRoomQueryDBContex> options) : base(options)
        {
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Scheduler> Schedulers { get; set; }
        public DbSet<RoomScheduler> RoomSchedulers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoomMap());
            modelBuilder.ApplyConfiguration(new SchedulerMap());
            modelBuilder.ApplyConfiguration(new RoomSchedulerMap());
        }

    }
}
