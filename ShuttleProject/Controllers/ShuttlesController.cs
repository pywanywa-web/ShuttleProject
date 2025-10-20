using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShuttleProject.Models;

namespace ShuttleProject.Controllers
{
    public class ShuttlesController : Controller
    {
        private AppDbContext _appDbContext;
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
            return View();
        }

        // POST: ShuttlesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add([FromForm] Shuttles request)
        {
            _appDbContext.Shuttles.Add(request);
            _appDbContext.SaveChanges();

            return View(RedirectToAction(nameof(Index)));  
        }

        // GET: ShuttlesController/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShuttlesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromForm] Shuttles request)
        {
            _appDbContext.Shuttles.Update(request);
            _appDbContext.SaveChanges();

            return View(RedirectToAction(nameof(Index)));
        }

        // GET: ShuttlesController/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShuttlesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromForm] Shuttles request)
        {
            _appDbContext.Shuttles.Remove(request);
            _appDbContext.SaveChanges();

            return View(RedirectToAction(nameof(Index)));
        }
    }
}
