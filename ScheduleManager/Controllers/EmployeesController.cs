using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EWSoftware.PDI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScheduleManager.Data;
using ScheduleManager.Data.Entities;

namespace ScheduleManager.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ScheduleManagerDbContext _context;

        public EmployeesController(ScheduleManagerDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var employees = await _context.Employees.ToListAsync();

            return View(employees);
        }


        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,Firstname,Lastname")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
                return NotFound();

            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,Firstname,Lastname")] Employee employee)
        {
            if (id != employee.EmployeeId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!EmployeeExists(employee.EmployeeId))
                        return NotFound();

                    throw ex;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.EmployeeId == id);

            if (employee == null)
                return NotFound();

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Employees/1/Schedules
        public async Task<IActionResult> ShowSchedules(int employeeId)
        {
            var employee = await _context.Employees
                .Include(e => e.Schedules)
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);

            if (employee == null)
                return NotFound();

            return View(employee);
        }

        // GET: Employees/1/Schedules/Add
        [Route("Employees/{employeeId}/Schedules/Add")]
        public async Task<IActionResult> AddSchedule(int employeeId)
        {
            var employee = await _context.Employees
                .Include(e => e.Schedules)
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);

            if (employee == null)
                return NotFound();

            var schedule = new MasterSchedule()
            {
                EmployeeId = employee.EmployeeId,
                Employee = employee,
            };

            return View(schedule);
        }

        // POST: Employees/1/Schedules/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Employees/{employeeId}/Schedules/Add")]
        public async Task<IActionResult> AddSchedule([Bind()] MasterSchedule schedule)
        {
            var employee = _context.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == schedule.EmployeeId);

            if (employee == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                // TODO: Generate rrule here.
                var r = new Recurrence()
                {
                    StartDateTime = schedule.StartDate,
                    Frequency = (RecurFrequency)schedule.Frequency,
                    CanOccurOnHoliday = schedule.CanOccurOnHolidays
                };

                if (!schedule.RepeatsIndefinitely)
                {
                    if (schedule.EndDate == null)
                        throw new ArgumentNullException();

                    r.RecurUntil = (DateTime)schedule.EndDate;
                }

                if (schedule.IsOnWeekdays)
                    r.RecurEveryWeekday();
                else
                    r.Interval = schedule.Interval;

                if (schedule.Frequency == RecurFrequency.Weekly)
                {
                    r.ByDay.AddRange(schedule.Days
                        .Select(day => (System.DayOfWeek)day));

                    if(schedule.Days.Count > 0)
                        foreach (var day in schedule.Days)
                            schedule.DaysOfWeek.Add(await _context.DaysOfWeek.FindAsync(day));
                }

                _context.Add(schedule);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(ShowSchedules), new { EmployeeId = schedule.EmployeeId });
            }

            return View(schedule);
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }
    }
}