using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShuttleProject.Models.Data.MonitoringSystem;
//using ShuttleProject.Models.Data;
using System.Collections.Generic;
using System.Linq;

namespace ShuttleProject.Controllers
{
    public class PassengersController : Controller
    {
        private MonitoringSystemContext _context;

        public PassengersController(MonitoringSystemContext context)
        {
            _context = context;
        }   
        // GET: PassengersController
        public IActionResult Index()
        {
            List<Passenger> passenger = _context.Passengers.OrderBy(s => s.PassengerId).ToList();
            return View(passenger);
        }

        // GET: PassengersController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: PassengersController/Create
        public IActionResult Add()
        {
            ViewBag.TypeOptions = GetTypeOptions();
            return View();
        }

        // POST: PassengersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add([FromForm] Passenger request)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.TypeOptions = GetTypeOptions();
                return View(request);
            }

            _context.Passengers.Add(request);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        
        // GET: PassengersController/Edit/5
        public IActionResult Edit(int id)
        {
            Passenger? passenger = _context.Passengers.Find(id);
            if (passenger == null)
            {
                return NotFound();
            }
            ViewBag.TypeOptions = GetTypeOptions();
            return View(passenger);
        }

        // POST: PassengersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromForm] Passenger request)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.TypeOptions = GetTypeOptions();
                return View(request);
            }

            _context.Passengers.Update(request);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        
        // GET: PassengersController/Delete/5
        public IActionResult Delete(int id)
        {
            Passenger? passenger = _context.Passengers.Find(id);
            if (passenger == null)
            {
                return NotFound();
            }
            return View(passenger);
        }

        // POST: PassengersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromForm] Passenger request)
        {
            _context.Passengers.Remove(request);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));     
        }

        private IEnumerable<SelectListItem> GetTypeOptions()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Text = "Student", Value = "Student" },
                new SelectListItem { Text = "Staff", Value = "Staff" }
            };
        }
    }
}
