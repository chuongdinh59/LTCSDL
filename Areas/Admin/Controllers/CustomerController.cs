using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildingDemo.Areas.Admin.Service;
using BuildingDemo.Models;

namespace BuildingDemo.Areas.Admin.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerService customerService = new CustomerService();
        // GET: Admin/Customer
        public ActionResult Index()
        {
            List<Customer> customers = customerService.getAll();
            return View(customers);
        }
        private ActionResult View(List<Customer> customers )
        {
            ViewBag.customers = customers;
            
            return View();
        }
        // GET: Admin/Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Customer/Create
        [HttpPost]
        [Obsolete]
        public ActionResult Create(Customer customer, HttpPostedFileBase Avatar)
        {
            try
            {
                bool result = customerService.CreateCustomer(customer, Avatar);
                if (result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["SavevError"] = "Fail to save the building record.";
                    return RedirectToAction("Create");
                }
                // TODO: Add insert logic here  
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Customer/Edit/5
        public ActionResult Edit(int id)
        {
            Customer customer = customerService.findByID(id);
            return View(customer);
        }

        // POST: Admin/Customer/Edit/5
        [HttpPost]
        [Obsolete]
        public ActionResult Edit(int id, Customer customer, HttpPostedFileBase Avatar)
        {
            try
            {
                bool isUpdated = customerService.UpdateInfoCustomer(customer, Avatar);

                if(isUpdated)
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



        // POST: Admin/Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                bool IsDeleted = customerService.DeleteCustomer(id);
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
                return RedirectToAction("Index");
            }
        }
    }
}
