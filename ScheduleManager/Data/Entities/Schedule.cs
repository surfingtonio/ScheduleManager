﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ScheduleManager.Data.Entities
{
    public partial class Schedule
    {
        [Display(Name = "Schedule")]
        public int ScheduleId { get; set; }

        [Required]
        public string Title { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Start End")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Duration")]
        public float DurationHours { get; set; }

        [Display(Name = "Recurrence")]
        public int RepeatAfterDays { get; set; }

        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

    }
}