using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildingDemo.Areas.Admin.Service;
using BuildingDemo.Models;

namespace BuildingDemo.Areas.Admin.Controllers
{
    public class ScheduleController : Controller
    {
        private BuildingService buildingService = new BuildingService();
        private EmployeeService employeeService = new EmployeeService();
        private ScheduleService scheduleService = new ScheduleService();
        // GET: Admin/Schedule
        public ActionResult Index()
        {
            List<Schedule> schedules = scheduleService.FindAll();
            List<Building> buildings = buildingService.getAll().ToList();
            List<Employee> employees = employeeService.getAll();

            var scheduleViewModels = schedules.Select(s => new ScheduleViewModel {
                Schedule = s,
                BuildingName = buildings.FirstOrDefault(b => b.ID == s.BuildingID)?.Name,
                EmployeeName = employees.FirstOrDefault(e => e.ID == s.EmployeeID)?.Name
            }).ToList();

            return View(scheduleViewModels);
        }
        private ActionResult View(List<Building> buildings, List<Employee> employees)
        {
            ViewBag.buildings = buildings;
            ViewBag.employees = employees;
            return View();
        }
        // GET: Admin/Schedule/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Schedule/Create
        public ActionResult Create()
        {
            List<Building> buildings = buildingService.getAll().ToList();
            List<Employee> employees = employeeService.getAll();
            return View(buildings, employees);
        }

        // POST: Admin/Schedule/Create
        [HttpPost]
        public ActionResult Create(string BuildingID, int? EmployeeID, DateTime? DateAppointment, bool? Time)
        {
            try
            {
                if (BuildingID == null || EmployeeID == null ||  DateAppointment == null || Time == null)
                {
                    TempData["ErrorMessage"] = "Thêm lịch không thành công vì thiếu dữ liệu";
                    return RedirectToAction("Create");
                }
                string result = scheduleService.CreateSchedule(BuildingID, EmployeeID, DateAppointment, Time);
                if (result == "success")
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ErrorMessage"] = result;
                    return RedirectToAction("Create");
                }
                // TODO: Add insert logic here

            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Schedule/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Schedule/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Schedule/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Schedule/Delete/5
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
