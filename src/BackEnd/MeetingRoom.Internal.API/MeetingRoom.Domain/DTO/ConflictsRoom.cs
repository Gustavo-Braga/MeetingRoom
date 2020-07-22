using System;
using System.Collections.Generic;

namespace MeetingRoom.Domain.DTO
{
    public class ConflictsRoom
    {
        public ConflictsRoom(Guid idRoom, string name, IEnumerable<SchedulerConflict> schedulerConflicts)
        {
            IdRoom = idRoom;
            Name = name;
            SchedulerConflicts = schedulerConflicts;
        }

        public Guid IdRoom { get; set; }
        public string Name { get; set; }
        public IEnumerable<SchedulerConflict> SchedulerConflicts { get; set; }
    }
}
