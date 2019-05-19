using ScheduleManager.Data.Entities;
using System.Collections.Generic;

namespace ScheduleManager.Models
{
    public class CalendarViewModel
    {
        public int SelectedEmployeeId { get; set; }

        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
