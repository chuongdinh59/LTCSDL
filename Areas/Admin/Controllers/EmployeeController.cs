using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildingDemo.Areas.Admin.Service;
using BuildingDemo.Models;

namespace BuildingDemo.Areas.Admin.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeService employeeService = new EmployeeService();
        // GET: Admin/Employee
        public ActionResult Index()
        {
            List<Employee> employees = employeeService.getAll();
            return View(employees);
        }

        // GET: Admin/Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Employee/Create
        [HttpPost]
        [Obsolete]
        public ActionResult Create(Employee employee, HttpPostedFileBase Avatar)
        {
            try
            {
                bool result = employeeService.CreateEmployee(employee, Avatar);
                if (result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["SavevError"] = "Fail to save the employee record.";
                    return RedirectToAction("Create");
                }
                // TODO: Add insert logic here  
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Employee/Edit/5
        public ActionResult Edit(int id)
        {
            Employee employee = employeeService.findByID(id);
            return View(employee);
        }

        // POST: Admin/Employee/Edit/5
        [HttpPost]
        [Obsolete]
        public ActionResult Edit(int id, HttpPostedFileBase Avatar, Employee employee)
        {
            try
            {
                bool isUpdated = employeeService.UpdateEmployee(employee, Avatar);

                if (isUpdated)
                {
                    TempData["SaveSuccess"] = "Thay đổi thông tin thành công";
                }
                else
                {
                    TempData["SaveError"] = "Thay đổi thông tin không thành công";
                }
                return RedirectToAction("Edit", new { id = id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                bool IsDeleted = employeeService.DeleteEmploye(id);
                // TODO: Add delete logic here
                if (IsDeleted)
                {
                    TempData["DeleteSuccess"] = "Xóa thông tin thành công";
                }
                else
                {
                    TempData["DeleteError"] = "Xóa thông tin thất bại hoặc không tìm thấy thông tin";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
