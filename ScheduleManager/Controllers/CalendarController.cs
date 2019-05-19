using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScheduleManager.Data;
using ScheduleManager.Data.Entities;
using ScheduleManager.Models;
using EWSoftware.PDI;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ScheduleManager.Controllers
{
    public class CalendarController : Controller
    {
        private readonly ScheduleManagerDbContext _context;

        public CalendarController(ScheduleManagerDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var employee = await _context.Employees.FirstOrDefaultAsync();

            if(employee == null)
            {
                return RedirectToAction("Index", "Employees");
            }

            return View(new CalendarViewModel
            {
                Employees = _context.Employees.ToList(),
                SelectedEmployeeId = employee.EmployeeId
            });
        }
    }
}