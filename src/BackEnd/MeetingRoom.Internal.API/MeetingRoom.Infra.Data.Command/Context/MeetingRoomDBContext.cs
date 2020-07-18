using MeetingRoom.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MeetingRoom.Infra.Data.Command.Context
{
    public class MeetingRoomDBContext : DbContext
    {
        public MeetingRoomDBContext(DbContextOptions<MeetingRoomDBContext> options) : base(options)
        {
        }

        public DbSet<Room> Rooms { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            RoomMap(modelBuilder);

        }

        private void RoomMap(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().ToTable("Room");
            modelBuilder.Entity<Room>().HasKey(x => x.Id).HasName("Id");
            modelBuilder.Entity<Room>().Property(x => x.Name).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Room>().Property(x => x.Description).HasMaxLength(100);
        }
    }
}
