using MeetingRoom.Domain.DTO;
using System;
using System.Collections.Generic;

namespace MeetingRoom.CommandHandler.Commands.Scheduler.Update
{
    public class UpdateSchedulerResponse
    {
        public Guid Id { get; set; }
        public IEnumerable<ConflictsRoom> ConflictsRooms { get; set; }
    }
}
