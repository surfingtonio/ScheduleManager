using EWSoftware.PDI;
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

        // GET: api/Calendar/5?StartDate=2019-01-01&EndDate=2019-02-05
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<FullCalendarEvent>>> GetSchedules(int id, [FromQuery] DateRange dateRange)
        {
            var employee = await _context.Employees
                .Include(e => e.Schedules)
                .FirstOrDefaultAsync(e => e.EmployeeId == id);

            if (employee == null)
            {
                return NotFound();
            }

            var events = new List<FullCalendarEvent>();
            var recurrence = new Recurrence();
            foreach (var schedule in employee.Schedules)
            {
                recurrence.StartDateTime = schedule.StartDate;
                recurrence.RecurDaily(schedule.Interval);

                var timespan = schedule.EndDate == null ?
                    new System.TimeSpan(24, 0, 0) :
                    schedule.EndDate - schedule.StartDate;
                var dates = recurrence.InstancesBetween(dateRange.Start, dateRange.End);
                foreach (var item in dates.Select((date, index) => new { date, index }))
                {
                    events.Add(new FullCalendarEvent
                    {
                        Id = $"event_{schedule.EmployeeId}_{schedule.ScheduleId}_{item.index.ToString().PadLeft(5, '0')}",
                        GroupId = $"event_{schedule.EmployeeId}_{schedule.ScheduleId}",
                        Title = schedule.Title,
                        Start = item.date,
                        End = item.date.AddHours(timespan.Value.Hours)
                    });
                }
            }

            return events;
        }

    }
}
