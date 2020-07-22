using MeetingRoom.Domain.DTO;
using System;
using System.Collections.Generic;

namespace MeetingRoom.CommandHandler.Commands.Scheduler.Add
{
    public class AddSchedulerResponse
    {
        public Guid Id { get; set; }
        public IEnumerable<ConflictsRoom> ConflictsRooms { get; set; }
    }
}
