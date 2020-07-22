using MeetingRoom.Infra.Data.Query.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeetingRoom.Infra.Data.Query.Mapping
{
    public class SchedulerMap : IEntityTypeConfiguration<Scheduler>
    {
        public void Configure(EntityTypeBuilder<Scheduler> builder)
        {
            builder.ToTable("Scheduler");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.EndDate).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(100).IsRequired();

            builder.HasMany(x => x.RoomSchedulers)
                .WithOne(x => x.Scheduler)
                .HasForeignKey(x => x.IdScheduler);
        }
    }
}
