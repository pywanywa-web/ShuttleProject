using Microsoft.AspNetCore.Mvc;
using ShuttleProject.Models;

namespace ShuttleProject.Controllers
{
    public class DriversController : Controller
    {
        private AppDbContext _appDbContext;
        public DriversController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }   
        // GET: DriverController
        public ActionResult Index()
        {
            List<Drivers> drivers = _appDbContext.Drivers.OrderBy(s => s.DriverId).ToList();
            return View(drivers);
        }

        // GET: DriverController/Details/5
        public ActionResult Details(int id)
        {
            Drivers driver = _appDbContext.Drivers.Find(id);
            return View(driver);
        }

        // GET: DriverController/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: DriverController/Create
        [HttpPost]
        public IActionResult Add([FromForm] Drivers request)
        {
            _appDbContext.Drivers.Add(request); 
            _appDbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: DriverController/Edit/5
        public IActionResult Edit(int id)
        {
            Drivers driver = _appDbContext.Drivers.Find(id);
            return View(driver);
        }

        // POST: DriverController/Edit/5
        [HttpPost]
        public IActionResult Edit([FromForm] Drivers request)
        {
            _appDbContext.Drivers.Update(request);
            _appDbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        //// GET: DriverController/Delete/5
        //public IActionResult Delete(int id)
        //{
        //    Drivers driver = _appDbContext.Drivers.Find(id);
        //    return View(driver);
            
        //}

        // POST: DriverController/Delete/5
        [HttpPost]
    
        public IActionResult Delete([FromForm] Drivers request)
        {
            _appDbContext.Drivers.Remove(request);
            _appDbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
