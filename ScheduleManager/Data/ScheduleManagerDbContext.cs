﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<Exception> Exceptions { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<DayOfWeek> DaysOfWeek { get; set; }
        public DbSet<MasterSchedule> MasterSchedules { get; set; }
    }
}
