using MeetingRoom.Infra.Data.Query.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeetingRoom.Infra.Data.Query.Mapping
{
    public class RoomSchedulerMap : IEntityTypeConfiguration<RoomScheduler>
    {
        public void Configure(EntityTypeBuilder<RoomScheduler> builder)
        {
            builder.ToTable("RoomScheduler");
            builder.HasKey(x => new { x.IdRoom, x.IdScheduler });
        }
    }
}
