using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuildingDemo.Areas.Staff.Controllers
{
    public class ScheduleStaffController : Controller
    {
        // GET: Staff/ScheduleStaff
        public ActionResult Index()
        {
            return View();
        }

        // GET: Staff/ScheduleStaff/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Staff/ScheduleStaff/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Staff/ScheduleStaff/Create
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

        // GET: Staff/ScheduleStaff/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Staff/ScheduleStaff/Edit/5
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

        // GET: Staff/ScheduleStaff/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Staff/ScheduleStaff/Delete/5
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
