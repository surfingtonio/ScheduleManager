using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ScheduleManager.Data.Entities
{
    public partial class Employee
    {

        public Employee()
        {
            Schedules = new HashSet<Schedule>();
        }

        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Fullname
        {
            get
            {
                return Firstname + " " + Lastname;
            }
        }

        public ICollection<Schedule> Schedules { get; set; }

    }
}
