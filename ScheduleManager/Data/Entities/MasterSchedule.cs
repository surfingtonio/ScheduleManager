﻿using EWSoftware.PDI;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleManager.Data.Entities
{
    public class MasterSchedule
    {
        public int MasterScheduleId { get; set; }

        public string Title { get; set; } = "Untitled Event";

        public DateTime StartDate { get; set; } = DateTime.Now;

        public int DurationHours { get; set; } = 8;

        public RecurFrequency Frequency { get; set; } = RecurFrequency.Weekly;

        public int Interval { get; set; } = 1;

        public DateTime? EndDate { get; set; }

        public bool IsAllDay { get; set; }

        public bool IsOnWeekdays { get; set; }

        public bool CanOccurOnHolidays { get; set; }

        public bool RepeatsIndefinitely { get; set; } = true;

        [NotMapped]
        public List<int> Days { get; set; }

        public virtual ICollection<DayOfWeek> DaysOfWeek { get; set; } = new HashSet<DayOfWeek>();

        public virtual int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
