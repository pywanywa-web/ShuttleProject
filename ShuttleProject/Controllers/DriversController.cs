using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShuttleProject.Models.Data.MonitoringSystem;

namespace ShuttleProject.Controllers
{
    public class DriversController : Controller
    {
        private MonitoringSystemContext _context;
        public DriversController(MonitoringSystemContext context)
        {
            _context = context;
        }
        // GET: DriverController
        public async Task<ActionResult> Index()
        { 
            var drivers = await _context.Drivers
                .AsNoTracking()
                .OrderBy(d => d.DriverId)
                .ToListAsync();

            return View(drivers);
        }

        // GET: DriverController/Details/5
        public ActionResult Details(int id)
        {
            Driver driver = _context.Drivers.Find(id);
            if (driver == null)
            {
                return NotFound();
            }
            return View(driver);
        }

        // GET: DriverController/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: DriverController/Create
        [HttpPost]
        public IActionResult Add(Driver request)
        {
            _context.Drivers.Add(request); 
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: DriverController/Edit/5
        public IActionResult Edit(int id)
        {
            var driver = _context.Drivers.Where(x => x.DriverId == id).FirstOrDefault();
            if (driver == null)
            {
                return NotFound();
            }
            return View(driver);
        }

        // POST: DriverController/Edit/5
        [HttpPost]
        public IActionResult Edit(Driver request)
        {
            _context.Drivers.Update(request);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        //// GET: DriverController/Delete/5
        public IActionResult Delete(int id)
        {
            Driver? driver = _context.Drivers.Find(id);
            if (driver == null)
            {
                return NotFound();
            }
            return View(driver);

        }

        // POST: DriverController/Delete/5
        [HttpPost]
    
        public IActionResult Delete(Driver request)
        {
            _context.Drivers.Remove(request);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }   
    }
}           
