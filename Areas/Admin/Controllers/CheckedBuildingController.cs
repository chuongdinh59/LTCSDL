using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildingDemo.Areas.Admin.Service;
using BuildingDemo.Models;

namespace BuildingDemo.Areas.Admin.Controllers
{
    public class CheckedBuildingController : Controller
    {
        private BuildingService buildingService = new BuildingService();
        // GET: Admin/CheckedBuilding
        public ActionResult Index()
        {
            List<Building> buildings = buildingService.GetBuildingsNotResolve();
            return View(buildings);
        }
       
     
        // GET: Admin/CheckedBuilding/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/CheckedBuilding/Create
        public ActionResult Create()
        {
            
            return RedirectToAction("Index");
        }

        // POST: Admin/CheckedBuilding/Create
        [HttpPost]
        public ActionResult Create(string id)
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

        // GET: Admin/CheckedBuilding/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/CheckedBuilding/Edit/5
        [HttpPost]
        public ActionResult Edit(string id)
        {
            try
            {
                // TODO: Add update logic here
                bool isResolve = buildingService.chageResolve(id);
                if (isResolve)
                {
                    TempData["ChangeResolveSucc"] = "Chuyển trạng thái thành công";

                    // Không redirect được ?
                    return RedirectToAction("Index", "CheckedBuilding");

                }
                else
                {
                    TempData["ChangeResolveErr"] = "Không thể chuyển trạng thái vì không tồn tại";
                    return RedirectToAction("CheckedBuilding", "Admin");

                }
            }
            catch
            {
                return RedirectToAction("CheckedBuilding", "Admin");
            }
        }

        // GET: Admin/CheckedBuilding/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/CheckedBuilding/Delete/5
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
