using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShuttleProject.Models.Data.MonitoringSystem;
using ShuttleProject.Models.ViewModel;



//using ShuttleProject.Models.Data;
using System.Linq;

namespace ShuttleProject.Controllers
{                           
    public class ShuttlesController : Controller
    {
        private readonly MonitoringSystemContext _context;
        public ShuttlesController(MonitoringSystemContext context)
        {
            _context = context;
        }

        // GET: ShuttlesController
        public ActionResult Index()
        {
            List<Shuttle> shuttles = _context.Shuttles.OrderBy(s => s.ShuttleId).ToList();
            return View(shuttles);
            
        }

        // GET: ShuttlesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ShuttlesController/Create
        public ActionResult Add()
        {
            //ViewData["Drivers"] = new SelectList(_context.Drivers.OrderBy(d => d.DriverId).ToList(), "DriverId", "Name");
            return View();
        }
            
        // POST: /Shuttles/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ShuttleViewModel model)
        {
            //ViewData["Drivers"] = new SelectList(_context.Drivers.OrderBy(d => d.DriverId).ToList(), "DriverId", "Name");

            //if (!ModelState.IsValid)
            //    return View(model);

            //// handle sentinel (-1) and null
            //if (model.DriverId == -1 || !_context.Drivers.Any(d => d.DriverId == model.DriverId))
            //{
            //    ModelState.AddModelError(nameof(model.DriverId), "Please select a valid driver.");
            //    return View(model);
            //}

            Shuttle shuttle = new()
            {
                ShuttleId = model.ShuttleId,
                DriverId = model.DriverId,
                PlateNumber = model.PlateNumber,
                Capacity = model.Capacity,
                Status = model.Status
            };
            _context.Shuttles.Add(shuttle);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: ShuttlesController/Edit/5
        public IActionResult Edit(string id)
        {
            Shuttle? shuttle = _context.Shuttles.Find(id);
            if (shuttle == null)
            {
                return NotFound();
            }
            return View(shuttle);
        }

        // POST: ShuttlesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromForm] Shuttle request)
        {
            _context.Shuttles.Update(request);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: ShuttlesController/Delete/5
        public IActionResult Delete(string id)
        {
            Shuttle? shuttle = _context.Shuttles.Find(id);
            if (shuttle == null)
            {
                return NotFound();
            }
            return View(shuttle);
            
        }

        // POST: ShuttlesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromForm] Shuttle request)
        {
            _context.Shuttles.Remove(request);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
