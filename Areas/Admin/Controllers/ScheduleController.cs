using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuildingDemo.Areas.Admin.Controllers
{
    public class ScheduleController : Controller
    {
        // GET: Admin/Schedule
        public ActionResult Index()
        {
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
            return View();
        }

        // POST: Admin/Schedule/Create
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
