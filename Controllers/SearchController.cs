using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildingDemo.Service;
using PagedList;

namespace BuildingDemo.Controllers
{
    public class SearchController : Controller
    {
        BuildingService buildingService = new BuildingService();
        // GET: Search
        public ActionResult SearchResult(string keyword, int? page, double? price, int? BuildingTypeID, string address, int? beds, int? baths)
        {
            int pageNumber = (page ?? 1);
            int size = 9;
            var result = buildingService.Search(keyword, price, BuildingTypeID, address, beds, baths);
            ViewBag.keywork = keyword;
            return View(result.OrderBy(b => b.Name).ToPagedList(pageNumber, size));
        }
        public ActionResult SearchKW(string keyword, double? price, int? BuildingTypeID, string address, int? beds, int? baths)
        {
            return RedirectToAction("SearchResult", new { @keyword = keyword, @price = price, @BuildingTypeID = BuildingTypeID, @address = address, @beds = beds, @baths = baths });
        }


        // GET: Search/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Search/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Search/Create
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

        // GET: Search/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Search/Edit/5
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

        // GET: Search/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Search/Delete/5
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