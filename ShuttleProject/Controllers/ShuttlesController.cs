using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShuttleProject.Models;
using ShuttleProject.Models.Data;
using System.Linq;

namespace ShuttleProject.Controllers
{                           
    public class ShuttlesController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public ShuttlesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // GET: ShuttlesController
        public IActionResult Index()
        {
            List<Shuttles> shuttles = _appDbContext.Shuttles.OrderBy(s => s.ShuttleId).ToList();
            return View(shuttles);
            
        }

        // GET: ShuttlesController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: ShuttlesController/Create
        public IActionResult Add()
        {
            ViewData["Drivers"] = new SelectList(_appDbContext.Drivers.OrderBy(d => d.DriverId).ToList(), "DriverId", "Name");
            return View();
        }
            
        // POST: /Shuttles/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add([FromForm] Shuttles request)
        {
            ViewData["Drivers"] = new SelectList(_appDbContext.Drivers.OrderBy(d => d.DriverId).ToList(), "DriverId", "Name");

            if (!ModelState.IsValid)
                return View(request);

            // handle sentinel (-1) and null
            if (request.DriverId == null || request.DriverId == -1 || !_appDbContext.Drivers.Any(d => d.DriverId == request.DriverId.Value))
            {
                ModelState.AddModelError(nameof(request.DriverId), "Please select a valid driver.");
                return View(request);
            }

            _appDbContext.Shuttles.Add(request);
            _appDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: ShuttlesController/Edit/5
        public IActionResult Edit(string id)
        {
            Shuttles shuttle = _appDbContext.Shuttles.Find(id);
            return View(shuttle);
        }

        // POST: ShuttlesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromForm] Shuttles request)
        {
            _appDbContext.Shuttles.Update(request);
            _appDbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: ShuttlesController/Delete/5
        public IActionResult Delete(string id)
        {
            Shuttles shuttle = _appDbContext.Shuttles.Find(id);
            return View(shuttle);
            
        }

        // POST: ShuttlesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromForm] Shuttles request)
        {
            _appDbContext.Shuttles.Remove(request);
            _appDbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
