using System.Collections.Generic;

namespace ScheduleManager.Data.Entities
{
    public partial class Schedule : Event
    {
        public int ScheduleId { get; set; }

        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        public ICollection<Exception> Exceptions { get; set; } = new HashSet<Exception>();
    }
}