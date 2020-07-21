using System;
using System.Collections.Generic;
using System.Text;

namespace MeetingRoom.Domain.DTO
{
    public class ConflictsRoom
    {
        public Guid IdRoom { get; set; }
        public string Name { get; set; }
        public IEnumerable<SchedulerConflict> SchedulerConflicts { get; set; }
    }
}
