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
            SchedulerMap(modelBuilder);

        }

        private void RoomMap(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().ToTable("Room");
            modelBuilder.Entity<Room>().HasKey(x => x.Id);
            modelBuilder.Entity<Room>().Property(x => x.Name).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Room>().Property(x => x.Description).HasMaxLength(100);
            //modelBuilder.Entity<Room>()
            //   .HasOne(a => a.Scheduler)
            //   .WithOne(b => b.Author)
            //   .HasForeignKey<AuthorBiography>(b => b.AuthorRef);

        }

        private void SchedulerMap(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Scheduler>().ToTable("Scheduler");
            modelBuilder.Entity<Scheduler>().HasKey(x => x.Id);

            modelBuilder.Entity<Scheduler>().Property(x => x.StartDate).IsRequired();
            modelBuilder.Entity<Scheduler>().Property(x => x.EndDate).IsRequired();
            modelBuilder.Entity<Scheduler>().Property(x => x.Responsible).HasMaxLength(50).IsRequired();

            modelBuilder.Entity<Scheduler>().Property(x => x.Observation).HasMaxLength(100);
            modelBuilder.Entity<Scheduler>().HasIndex(x => x.IdRoom).IsUnique(false);

            modelBuilder.Entity<Scheduler>().HasOne(x => x.Room).WithOne(y => y.Scheduler).HasForeignKey<Scheduler>(z => z.IdRoom);
        }
    }
}
