using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScheduleManager.Data;
using ScheduleManager.Data.Entities;

namespace ScheduleManager.Controllers
{
    public class SchedulesController : Controller
    {
        private readonly ScheduleManagerDbContext _context;

        public SchedulesController(ScheduleManagerDbContext context)
        {
            _context = context;
        }

        // GET: Schedules
        public async Task<IActionResult> Index()
        {
            var schedules = await _context.Schedules
                .Include(s => s.Employee)
                .ToListAsync();

            return View(schedules);
        }

        // GET: Schedules/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var schedule = await _context.Schedules
                .Include(s => s.Employee)
                .FirstOrDefaultAsync(m => m.ScheduleId == id);

            if (schedule == null)
                return NotFound();

            return View(schedule);
        }

        // GET: Schedules/Create
        public async Task<IActionResult> Create(int id)
        {
            var employee = await _context.Employees
                .Include(e => e.Schedules)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);

            if (employee == null)
                return NotFound();

            var schedule = new Schedule()
            {
                EmployeeId = employee.EmployeeId,
                Employee = employee
            };

            return View(schedule);
        }

        // POST: Schedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ScheduleId,Title,StartDate,EndDate,DurationHours,RepeatAfterDays,EmployeeId")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(schedule);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(schedule);
        }

        // GET: Schedules/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var schedule = await _context.Schedules.FindAsync(id);

            if (schedule == null)
                return NotFound();

            return View(schedule);
        }

        // POST: Schedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ScheduleId,Title,StartDate,EndDate,DurationHours,RepeatAfterDays,EmployeeId")] Schedule schedule)
        {
            if (id != schedule.ScheduleId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!ScheduleExists(schedule.ScheduleId))
                        return NotFound();

                        throw ex;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(schedule);
        }

        // GET: Schedules/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var schedule = await _context.Schedules
                .Include(s => s.Employee)
                .FirstOrDefaultAsync(m => m.ScheduleId == id);

            if (schedule == null)
                return NotFound();

            return View(schedule);
        }

        // POST: Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var schedule = await _context.Schedules.FindAsync(id);
            _context.Schedules.Remove(schedule);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ScheduleExists(int id)
        {
            return _context.Schedules.Any(e => e.ScheduleId == id);
        }
    }
}
