using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildingDemo.Models;
using BuildingDemo.Service;
using PagedList;

namespace BuildingDemo.Controllers
{
    public class UserController : Controller
    {
        private BuildingService buildingService = new BuildingService();
        private BuildingTypeService buildingTypeService = new BuildingTypeService();
        private CustomerService customerService = new CustomerService();

        // GET: User
        public ActionResult Index(/*int? page*/)
        {
            int id = (int)Session["ID"];
            List<Building> buildings = buildingService.GetAll().Where(b => b.IsResolve == false).ToList();
            Customer customer = customerService.FindByAccountID(id);

            //int pageSize = 3; // số phần tử trên mỗi trang
            //int pageNumber = (page ?? 1); // trang hiện tại (nếu không có thì mặc định là trang 1)
            return View(buildings/*.ToPagedList(pageNumber, pageSize)*/, customer);
        }
        private ActionResult View(/*IPaged*/List<Building> buildings, Customer customer)
        {
            ViewBag.buildings = buildings;
            ViewBag.customer = customer;
            return View();
        }
        // GET: User/Details/5
        public ActionResult Infor(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
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

        // GET: User/Edit/5
        public ActionResult Edit(string id)
        {
            List<BuildingType> buildingTypes = buildingTypeService.getAll().ToList();
            Building building = buildingService.FindByID(id);
            return View(buildingTypes, building);
        }
        private ActionResult View(List<BuildingType> buildingTypes, Building building)
        {
            ViewBag.buildingTypes = buildingTypes;
            ViewBag.building = building;
            return View();
        }
        // POST: Admin/Building/Edit/5
        [HttpPost]
        [Obsolete]
        public ActionResult Edit(Building newBuilding)
        {

            // Delete hình cũ
            // Delete trong bảng Images
            try
            {
                if (newBuilding == null)
                {
                    return HttpNotFound();
                }
                else
                {

                    bool result = buildingService.EditInfoBuilding(newBuilding);
                    //bool updateImage = buildingService.UpdateImage(newBuilding, Image, Images);
                    if (result)
                    {
                        TempData["SaveSuccess"] = "Sửa thông tin thành công";
                    }
                    else
                    {
                        TempData["SaveError"] = "Sửa thông tin thất bại";
                    }
                }
                return RedirectToAction("Edit", new { id = newBuilding.ID });

            }
            catch
            {
                return RedirectToAction("Index");
            }
        }



        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
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
