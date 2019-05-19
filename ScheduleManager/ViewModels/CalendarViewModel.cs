using ScheduleManager.Data.Entities;
using System.Collections.Generic;

namespace ScheduleManager.Models
{
    public class CalendarViewModel
    {
        public CalendarViewModel()
        {
            Employees = new List<Employee>();
        }

        public Employee SelectedEmployee { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
