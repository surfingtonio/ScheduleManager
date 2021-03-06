﻿using EWSoftware.PDI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScheduleManager.Data;
using ScheduleManager.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleManager.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private readonly ScheduleManagerDbContext _context;

        public CalendarController(ScheduleManagerDbContext context)
        {
            _context = context;
        }

        // GET: api/Calendar/5?Start=2019-04-22&End=2019-05-17
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<FullCalendarEvent>>> GetSchedules(int id, [FromQuery] DateRange dateRange)
        {
            var employee = await _context.Employees
                .Include(e => e.Schedules)
                    .ThenInclude(m => m.Exceptions)
                .FirstOrDefaultAsync(e => e.EmployeeId == id);

            if (employee == null)
            {
                return NotFound();
            }

            var events = new List<FullCalendarEvent>();
            foreach (var schedule in employee.Schedules)
            {
                var vacations = new DateTimeCollection();
                foreach (var exception in schedule.Exceptions)
                {
                    vacations.AddRange(exception.GetInstancesBetween(dateRange.Start, dateRange.End));
                }

                var shifts = new DateTimeCollection();
                shifts.AddRange(schedule.GetInstancesBetween(dateRange.Start, dateRange.End)
                    .Where(s => !vacations.Any(v => v.Date == s.Date)));

                var timespan = schedule.EndDate == null ?
                    new System.TimeSpan(24, 0, 0) :
                    schedule.EndDate - schedule.StartDate;

                foreach (var shift in shifts.Select((date, index) => new { date, index }))
                {
                    events.Add(new FullCalendarEvent
                    {
                        Id = $"event_{schedule.EmployeeId}_{schedule.ScheduleId}_{shift.index.ToString().PadLeft(5, '0')}",
                        GroupId = $"event_{schedule.EmployeeId}_{schedule.ScheduleId}",
                        Title = schedule.Title,
                        Start = shift.date,
                        End = shift.date.AddHours(timespan.Value.Hours)
                    });
                }
            }

            return events;
        }

    }
}
