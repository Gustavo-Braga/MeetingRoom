using MeetingRoom.Domain.Models;
using MeetingRoom.Infra.Data.Command.Mapping;
using Microsoft.EntityFrameworkCore;

namespace MeetingRoom.Infra.Data.Command.Context
{
    public class MeetingRoomDBContext : DbContext
    {
        public MeetingRoomDBContext(DbContextOptions<MeetingRoomDBContext> options) : base(options)
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
