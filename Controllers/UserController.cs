using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildingDemo.Filter;
using BuildingDemo.Models;
using BuildingDemo.Service;

namespace BuildingDemo.Controllers
{
    public class UserController : Controller
    {
        private BuildingService buildingService = new BuildingService();
        private BuildingTypeService buildingTypeService = new BuildingTypeService();
        private CustomerService customerService = new CustomerService();

        // GET: User
        [AuthenticationFilter]
        public ActionResult Index()
        {
            int id = (int)Session["ID"];
            Customer customer = customerService.FindByAccountID(id);
            List<Building> buildings = buildingService.GetBuildingFromCustomer(customer).Where(b => b.IsResolve == false).ToList();
            return View(buildings, customer);
        }
        private ActionResult View(List<Building> buildings, Customer customer)
        {
            ViewBag.buildings = buildings;
            ViewBag.customer = customer;
            return View();
        }
        // GET: User/Details/5
        [AuthenticationFilter]
        public ActionResult Infor()
        {
            int id = (int)Session["ID"];
            Customer customer = customerService.FindByAccountID(id);

            return View(customer);
        }

        [AuthenticationFilter]
        public ActionResult EditInfor()
        {
            int id = (int)Session["ID"];
            Customer customer = customerService.FindByAccountID(id);
            return View(customer);
        }
        // POST: User/Edit/5
        [HttpPost]
        [Obsolete]
        public ActionResult EditInfor(Customer newCustomer)
        {
            try
            {
                if (newCustomer == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    bool result = customerService.EditInfoCustomer(newCustomer);
                    if (result)
                    {
                        TempData["SaveSuccess"] = "Sửa thông tin thành công";
                    }
                    else
                    {
                        TempData["SaveError"] = "Sửa thông tin thất bại";
                    }
                }
                return RedirectToAction("EditInfo", new { id = newCustomer.ID });

            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult ChangePay(string BuildingID)
        {
            bool rs = buildingService.ChangePay(BuildingID);

            return RedirectToAction("Index");
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
        [AuthenticationFilter]
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
        public ActionResult Delete(string BuildingID)
        {
            try
            {
                // TODO: Add delete logic here
                bool rs = buildingService.DeleteBuilding(BuildingID);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}