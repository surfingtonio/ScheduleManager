using Microsoft.AspNetCore.Mvc.Rendering;
using ScheduleManager.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace ScheduleManager.Models
{
    public class ScheduleViewModel
    {
        [Display(Name = "Schedule")]
        public int ScheduleId { get; set; }

        public string Title { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Duration")]
        public float DurationHours { get; set; }

        [Display(Name = "Recurrence")]
        public int RepeatAfterDays { get; set; }

        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public SelectList Employees { get; set; }
    }
}
