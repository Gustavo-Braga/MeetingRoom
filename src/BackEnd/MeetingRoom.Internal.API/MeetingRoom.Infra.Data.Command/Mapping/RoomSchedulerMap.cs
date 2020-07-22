using MeetingRoom.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeetingRoom.Infra.Data.Command.Mapping
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
