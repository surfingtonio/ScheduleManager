using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleManager.Data.Entities
{
    public partial class Schedule
    {

        public int ScheduleId { get; set; }

        [Required]
        public string Title { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public float DurationHours { get; set; }

        public int RepeatAfterDays { get; set; }

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

    }
}