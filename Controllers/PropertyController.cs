using BuildingDemo.Models;
using BuildingDemo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace BuildingManagement.Controllers
{
    public class PropertyController : Controller
    {
        private BuildingService buildingService = new BuildingService();

        // GET: Property
        public ActionResult Index(int? page, int? pageSize)
        {
            int pageNumber = (page ?? 1);
            int size = 9;
            IEnumerable<Building> buildings = buildingService.getAll();
            var pageBuildings = buildings.ToPagedList(pageNumber, size);
            return View(pageBuildings);
        }

        // GET: Property/Details/5
        public ActionResult Details(String id)
        {
            List<Building> buildings = buildingService.getAll();
            var pageDetail = buildings.Find(b => b.ID.Equals(id));

            return View(pageDetail);
        }

        // GET: Property/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Property/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
