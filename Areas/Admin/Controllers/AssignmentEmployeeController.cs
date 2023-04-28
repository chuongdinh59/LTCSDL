using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildingDemo.Areas.Admin.Service;
using BuildingDemo.Models;

namespace BuildingDemo.Areas.Admin.Controllers
{
    public class AssignmentEmployeeController : Controller
    {
        private EmployeeService employeeService = new EmployeeService();
        private BuildingService buildingService = new BuildingService();
        private AssignBuildingService assignBuildingService = new AssignBuildingService();
        // GET: Admin/AssignmentEmployee
        public ActionResult Index()
        {
            List<Employee> employees = employeeService.getAll();
            return View(employees);
        }

        // GET: Admin/AssignmentEmployee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/AssignmentEmployee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AssignmentEmployee/Create
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
        public ActionResult EmployeeSchedule()
        {
            List<Employee> employees = employeeService.getAll();
            return View(employees);
        }
        // GET: Admin/AssignmentEmployee/Edit/5
        public ActionResult Edit(int id)
        {
            List<Building> buildings = buildingService.GetBuildingAssign();
            Employee employee = employeeService.findByID(id);
            List<ManagementBuilding> buildingChecked = assignBuildingService.getAll();
            return View(buildings, employee, buildingChecked);
        }
        private ActionResult View(List<Building> buildings, Employee employee, List<ManagementBuilding> buildingChecked)
        {
            ViewBag.buildings = buildings;
            ViewBag.employee = employee;
            ViewBag.buildingChecked = buildingChecked;
            return View();
        }

        // POST: Admin/AssignmentEmployee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, List<String> buildingids)
        {
            try
            {
                // TODO: Add update logic here
                bool result = employeeService.AssignBuilding(id, buildingids);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Schedule(int id)
        {
            HashSet<Schedule> schedules = assignBuildingService.GetScheduleByEmployee(id);
            return View(schedules);
        }
        // GET: Admin/AssignmentEmployee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/AssignmentEmployee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
