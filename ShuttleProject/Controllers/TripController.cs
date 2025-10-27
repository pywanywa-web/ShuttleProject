using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShuttleProject.Models;
using ShuttleProject.Models.Data.MonitoringSystem;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Trip = ShuttleProject.Models.Data.MonitoringSystem.Trip;


namespace ShuttleProject.Controllers
{
    public class TripController : Controller
    {
        private MonitoringSystemContext _context;

       
        public TripController(MonitoringSystemContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Trip> trip = _context.Trips.OrderBy(t => t.TripId).ToList();
            return View(trip);

        }
        public IActionResult Details(int id)
        {
            return View();
        }

        public IActionResult Add()
            {
            //ViewData["Shuttles"] = new SelectList(_context.Shuttles.OrderBy(s => s.ShuttleId).ToList(), "ShuttleId", "PlateNumber");
            ViewData["Routes"] = new SelectList(_context.Routes.OrderBy(r => r.RouteId).ToList(), "RouteId", "RouteName");
            ViewData["Passengers"] = new SelectList(_context.Passengers.OrderBy(p => p.PassengerId).ToList(), "PassengerId", "Name");

            return View();
            }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add([FromForm] Trip request)
        {
            //ViewData["Shuttles"] = new SelectList(_context.Shuttles.OrderBy(s => s.ShuttleId).ToList(), "ShuttleId", "PlateNumber");

            //if (!ModelState.IsValid)
            //    return View(request);

            //if (request.ShuttleId == "0" ||   !_context.Shuttles.Any(s => s.ShuttleId == request.ShuttleId))
            //{
            //    ModelState.AddModelError(nameof(request.ShuttleId), "Please select a valid PlateNumber.");
            //    return View(request);
            //}
            // handle sentinel (-1) and null


            ViewData["Routes"] = new SelectList(_context.Routes.OrderBy(r => r.RouteId).ToList(), "RouteId", "RouteName");

            if (!ModelState.IsValid)
                return View(request);

            // handle sentinel (-1) and null
            if (request.RouteId == -1 || !_context.Routes.Any(r => r.RouteId == request.RouteId))
            {
                ModelState.AddModelError(nameof(request.RouteId), "Please select a valid RouteName.");
                return View(request);
            }

            ViewData["Passengers"] = new SelectList(_context.Passengers.OrderBy(p => p.PassengerId).ToList(), "PassengerId", "Name");

            if (!ModelState.IsValid)
                return View(request);

            // handle sentinel (-1) and null
            if (request.PassengerId == -1 || !_context.Passengers.Any(p => p.PassengerId == request.PassengerId))
            {
                ModelState.AddModelError(nameof(request.PassengerId), "Please select a valid RouteName.");
                return View(request);
            }

            _context.Trips.Add(request);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Edit(int id)
        {
            ViewData["Routes"] = new SelectList(_context.Routes.OrderBy(r => r.RouteId).ToList(), "RouteId", "RouteName");

            Trip trip = _context.Trips.Find(id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromForm] Trip request)
        {

            ViewData["Routes"] = new SelectList(_context.Routes.OrderBy(r => r.RouteId).ToList(), "RouteId", "RouteName");

            if (!ModelState.IsValid)
                return View(request);

            // handle sentinel (-1) and null
            if (request.RouteId == -1 || !_context.Routes.Any(r => r.RouteId == request.RouteId))
            {
                ModelState.AddModelError(nameof(request.RouteId), "Please select a valid RouteName.");
                return View(request);
            }

            ViewData["Passengers"] = new SelectList(_context.Passengers.OrderBy(p => p.PassengerId).ToList(), "PassengerId", "Name");

            if (!ModelState.IsValid)
                return View(request);


            _context.Trips.Update(request);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


    }
}

