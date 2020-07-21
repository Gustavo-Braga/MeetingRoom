using MeetingRoom.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetingRoom.Infra.Data.Command.Mapping
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
