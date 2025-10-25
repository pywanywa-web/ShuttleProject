using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShuttleProject.Models.Data.MonitoringSystem;
using Route = ShuttleProject.Models.Data.MonitoringSystem.Route;


namespace ShuttleProject.Controllers
{
    public class RoutesController : Controller
    {
        private MonitoringSystemContext _context;

        public RoutesController (MonitoringSystemContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            List<Route> route = _context.Routes.OrderBy(static r => r.RouteId).ToList();
            return View(route);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add([FromForm] Route request)
        {

            _context.Routes.Add(request);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(int id)
        {
            Route? route = _context.Routes.Find(id);
            if (route == null)
            {
                return NotFound();
            }
            return View(route);
        }

        [HttpPost]
        public IActionResult Edit([FromForm] Route request)
        {
            _context.Routes.Update(request);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Route? route = _context.Routes.Find(id);
            if (route == null)
            {
                return NotFound();
            }
            return View(route);

        }

        [HttpPost]
        public IActionResult Delete([FromForm] Route request)
        {
           int id = request.RouteId;
            var route = _context.Routes.Find(id); // or FirstOrDefault, SingleOrDefault, etc.

            if (route != null)
            {
                 _context.Routes.Remove(route);
                //_appDbContext.SaveChanges();

                //return RedirectToAction(nameof(Index));
            }
            //_appDbContext.Routes.Remove(request);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}

