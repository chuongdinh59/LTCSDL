using BuildingDemo.Models;
using BuildingDemo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace BuildingManagement.Controllers
{


    public class HomeController : Controller
    {
        private BuildingService buildingService = new BuildingService();

        public ActionResult Index(int x = 3)
        {
            IEnumerable<Building> buildings = buildingService.getTop(x);

            return View(buildings);
        }

    }
}