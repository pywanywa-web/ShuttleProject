
using Microsoft.AspNetCore.Mvc;
using ShuttleProject.Models;
using ShuttleProject.Models.Data;

namespace ShuttleProject.Controllers
{
    public class RoutesController : Controller
    {
        private AppDbContext _appDbContext;

        public RoutesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {

            List<Routes> routes = _appDbContext.Routes.OrderBy(r => r.RouteId).ToList();
            return View(routes);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add([FromForm] Routes request)
        {

            _appDbContext.Routes.Add(request);
            _appDbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(int id)
        {

            Routes routes = _appDbContext.Routes.Find(id);
            return View(routes);
        }

        [HttpPost]
        public IActionResult Edit([FromForm] Routes request)
        {
            _appDbContext.Routes.Update(request);
            _appDbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Routes routes = _appDbContext.Routes.Find(id);
            return View(routes);

        }

        [HttpPost]
        public IActionResult Delete([FromForm] Routes request)
        {
           int id = request.RouteId;
            var route = _appDbContext.Routes.Find(id); // or FirstOrDefault, SingleOrDefault, etc.

            if (route != null)
            {
                 _appDbContext.Routes.Remove(route);
                //_appDbContext.SaveChanges();

                //return RedirectToAction(nameof(Index));
            }
            //_appDbContext.Routes.Remove(request);
            _appDbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}

