using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildingDemo.Areas.Admin.Service;
using BuildingDemo.Areas.Staff.Service;
using BuildingDemo.Filter;
using BuildingDemo.Models;

namespace BuildingDemo.Areas.Staff.Controllers
{
    public class StaffManagementController : Controller
    {
        private StaffService staffService = new StaffService();
        private BuildingService buildingService = new BuildingService();
        private BuildingTypeService buildingTypeService = new BuildingTypeService();
        // GET: Staff/StaffManagement
        public ActionResult Index()
        {
            if (Session != null && Session["ID"] != null && (int)Session["ID"] != 0)
            {
                List<Building> buildings = staffService.GetManagementBuilding((int)Session["ID"]);
                return View(buildings);

            }
            else
            {
                return Redirect("/Login/Login");
            }
        }
        public ActionResult Edit(string id)
        {
            List<BuildingType> buildingTypes = buildingTypeService.getAll().ToList();
            Building building = buildingService.findByID(id);
            return View(buildingTypes, building);
        }
        private ActionResult View(List<BuildingType> buildingTypes, Building building)
        {
            ViewBag.buildingTypes = buildingTypes;
            ViewBag.building = building;
            return View();
        }

        public ActionResult HandleManagement(string BuildingID)
        {
            int AccountID = (int)Session["ID"];
            bool rs = staffService.HandleDone(AccountID, BuildingID);
            return RedirectToAction("Index");
        }

        public ActionResult MySchedule()
        {
            int AccountID = (int)Session["ID"];
            HashSet<Schedule> schedules = staffService.GetScheduleByEmployee(AccountID);
            return View(schedules);
        }
    }
}