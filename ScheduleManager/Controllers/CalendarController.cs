using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScheduleManager.Data;
using ScheduleManager.Data.Entities;
using ScheduleManager.Models;

namespace ScheduleManager.Controllers
{
    public class CalendarController : Controller
    {
        private readonly ScheduleManagerDbContext _context;

        public CalendarController(ScheduleManagerDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = new CalendarViewModel
            {
                Employees = _context.Employees.ToList(),
                SelectedEmployee = _context.Employees.FirstOrDefault()
            };

            return View(data);
        }
    }
}