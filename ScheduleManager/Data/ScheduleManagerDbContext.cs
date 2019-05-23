using Microsoft.EntityFrameworkCore;
using ScheduleManager.Data.Entities;

namespace ScheduleManager.Data
{
    public class ScheduleManagerDbContext : DbContext
    {
        public ScheduleManagerDbContext()
        {
        }

        public ScheduleManagerDbContext(DbContextOptions<ScheduleManagerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<DayOfWeek> DaysOfWeek { get; set; }
    }
}
