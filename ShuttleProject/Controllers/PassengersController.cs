using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShuttleProject.Models;
using ShuttleProject.Models.Data;
using System.Collections.Generic;
using System.Linq;

namespace ShuttleProject.Controllers
{
    public class PassengersController : Controller
    {
        private AppDbContext _appDbContext;

        public PassengersController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }   
        // GET: PassengersController
        public IActionResult Index()
        {
            List<Passengers> passengers = _appDbContext.Passengers.OrderBy(s => s.PassengerId).ToList();
            return View(passengers);
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
        public IActionResult Add([FromForm] Passengers request)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.TypeOptions = GetTypeOptions();
                return View(request);
            }

            _appDbContext.Passengers.Add(request);
            _appDbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        
        // GET: PassengersController/Edit/5
        public IActionResult Edit(int id)
        {
            Passengers passenger = _appDbContext.Passengers.Find(id);
            ViewBag.TypeOptions = GetTypeOptions();
            return View(passenger);
        }

        // POST: PassengersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromForm] Passengers request)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.TypeOptions = GetTypeOptions();
                return View(request);
            }

            _appDbContext.Passengers.Update(request);
            _appDbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        
        // GET: PassengersController/Delete/5
        public IActionResult Delete(int id)
        {
            Passengers passenger = _appDbContext.Passengers.Find(id);
            return View(passenger);
        }

        // POST: PassengersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromForm] Passengers request)
        {
            _appDbContext.Passengers.Remove(request);
            _appDbContext.SaveChanges();

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
