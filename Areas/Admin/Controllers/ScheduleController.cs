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
        private CustomerService customerService = new CustomerService();
        private ScheduleService scheduleService = new ScheduleService();
        // GET: Admin/Schedule
        public ActionResult Index()
        {
            List<Schedule> schedules = scheduleService.GetBuildingsNotResolve();
            List<Building> buildings = buildingService.getAll().ToList();
            List<Customer> customers = customerService.getAll().ToList();
            var scheduleViewModels = schedules.Select(s => new ScheduleViewModelCustomer {
                Schedule = s,
                BuildingName = buildings.FirstOrDefault(b => b.ID == s.BuildingID)?.Name,
                CustomerName = customers.FirstOrDefault(c=> c.ID == s.CustomerID)?.Name,
                IsValid = scheduleService.checkIsValid(s.ID, s.BuildingID, s.EmployeeID, s.Time, s.Session),
                Session = (bool)s.Session
            }).ToList();

            return View(scheduleViewModels);
        }
     
       
        // GET: Admin/Schedule/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult ChangeStatus(int id)
        {
            // Duyệt lịch thành công

            bool result = scheduleService.changeStatusIsResolve(id);

            if (result)
            {
                TempData["ChangeSuccess"] = "Duyệt lịch hẹn thành công";
            }
            else
            {
                TempData["ChangeFail"] = "Duyệt lịch hẹn thấy bại";
            }
            
            return RedirectToAction("Index");
        }
        // GET: Admin/Schedule/Create
        public ActionResult Create(string id)
        {
            Building building = buildingService.findByID(id);
            List<Schedule> schedules = scheduleService.GetBuildingsResolveAndIsTarget(building);
            List<Employee> employees = employeeService.GetEmployeeMangement(building);
            return View(schedules, employees, building);
        }

        //POST: Admin/Schedule/Create
       [HttpPost]
        public ActionResult Create(int ScheduleID, int EmployeeID)
        {
            try
            {
                //string result = scheduleService.CreateSchedule(BuildingID, EmployeeID, DateAppointment, Time);
                bool result = scheduleService.AddEmployeeToSchedule(EmployeeID, ScheduleID);
                if (result)
                {
                    return RedirectToAction("Create");
                }
                else
                {
                    return RedirectToAction("Create");
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Schedule/Edit/5
        public ActionResult Edit(int id)
        {
            Schedule schedule = scheduleService.FindByID(id);
            return View(schedule);
        }
        private ActionResult View(Schedule schedule, List<Employee> employees)
        {
            ViewBag.schedule = schedule;
            ViewBag.employees = employees;
            return View();
        }
        private ActionResult View(List<Schedule> schedules, List<Employee> employees, Building building)
        {
            ViewBag.schedules = schedules;
            ViewBag.employees = employees;
            ViewBag.building = building;
            return View();
        }
        // POST: Admin/Schedule/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DateTime? DateAppointment, bool? Time)
        {   
            try
            {
                // TODO: Add update logic here
                bool result = scheduleService.EditSchedule(id, DateAppointment, Time);

                // Thông báo 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EmployeeSchedule()
        {
            List<Building> buildings = buildingService.getAll().ToList();
            List<Employee> employees = employeeService.getAll();
            return View(buildings, employees);
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

        private ActionResult View(List<Building> buildings, List<Employee> employees)
        {
            ViewBag.buildings = buildings;
            ViewBag.employees = employees;
            return View();
        }

        private ActionResult View(Building building, List<Employee> employees)
        {
            ViewBag.building = building;
            ViewBag.employees = employees;
            return View();
        }
    }
}
