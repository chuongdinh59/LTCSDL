using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuildingDemo.Areas.Staff.Controllers
{
    public class BuildingStaffController : Controller
    {
        // GET: Staff/BuildingStaff
        public ActionResult Index()
        {
            return View();
        }

        // GET: Staff/BuildingStaff/Details/5
        public ActionResult Details()
        {
            return View();
        }

        // GET: Staff/BuildingStaff/Create
        public ActionResult Success()
        {
            return View();
        }

        // POST: Staff/BuildingStaff/Create
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

        // GET: Staff/BuildingStaff/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Staff/BuildingStaff/Edit/5
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

        // GET: Staff/BuildingStaff/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Staff/BuildingStaff/Delete/5
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
