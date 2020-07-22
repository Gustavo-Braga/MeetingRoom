using System;
using System.Collections.Generic;
using System.Linq;

namespace MeetingRoom.Domain.Models
{
    public class Scheduler : EntitieBase<Guid>
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<RoomScheduler> RoomSchedulers { get; set; }

        public bool RoomIsDuplicated => RoomSchedulers.GroupBy(x => x.IdRoom).Any(x => x.Count() > 1);
    }
}
