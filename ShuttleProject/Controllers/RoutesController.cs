using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShuttleProject.Controllers
{
    public class RoutesController : Controller
    {
        // GET: RoutesController
        public IActionResult Index()
        {
            return View();
        }

        // GET: RoutesController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: RoutesController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoutesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RoutesController/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: RoutesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RoutesController/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: RoutesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
