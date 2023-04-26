using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using BuildingDemo.Areas.Admin.Service;
using BuildingDemo.Models;

namespace BuildingDemo.Areas.Admin.Controllers
{
    public class BuildingController : Controller
    {
        // GET: Admin/Building
        private BuildingService buildingService = new BuildingService();
        private BuildingTypeService buildingTypeService = new BuildingTypeService();
        private CustomerService customerService = new CustomerService();
        public ActionResult Index()
        {
            List<Building> buildings = buildingService.getAll().ToList();

            if (TempData.ContainsKey("ErrorMessage"))
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"];
            }
            return View(buildings);
        }

        // GET: Admin/Building/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Building/Create
        public ActionResult Create()
        {
            List<BuildingType> buildingTypes = buildingTypeService.getAll().ToList();
            return View(buildingTypes);
        }

        // POST: Admin/Building/Create
        [HttpPost]
        [Obsolete]
        public ActionResult Create(Building building , HttpPostedFileBase Image
            , List<HttpPostedFileBase> Images)
        {
            Guid uuid = Guid.NewGuid();
            string ID = building.ID + "-" + uuid.ToString();
            building.ID = ID;
            building.IsPay = false;
            building.IsResolve = false;
            if (Images[0] != null && Images.Count > 0)
            {
                for ( int i = 0; i < Images.Count; i++)
                {
                    Image img = new Image();
                    img.BuildingID = building.ID;
                    img.URL =  CloudinaryController.UploadImage(Images[i]);
                    building.Images.Add(img);
                }
            }
            if (Image != null) // Đoạn này kiểm tra có hình không 
            {
                building.Image = CloudinaryController.UploadImage(Image);
                if (building.Image != "")
                {
                    // Thành công 
                }
                else
                {
                    // Thất bại
                }
            }

            try
            {
                // TODO: Add insert logic here
                bool result = buildingService.save(building);
                if (result)
                {
                    TempData["SuccessMessage"] = "Success to save the building record.";
                    return RedirectToAction("Index");
                }
                else
                {
                    if (building.CustomerID != null)
                    {
                        Customer c = customerService.findByID((int)building.CustomerID);
                        if (c == null)
                            TempData["CustomerIDMessage"] = "Customer not exists ";
                    }
                    TempData["ErrorMessage"] = "Failed to save the building record.";
                    return RedirectToAction("Create");
                }
            }
            catch
            {
                
                return View();
            }
        }

        // GET: Admin/Building/Edit/5
        public ActionResult Edit(string id)
        {
            List<BuildingType> buildingTypes = buildingTypeService.getAll().ToList();
            Building building = buildingService.findByID(id);
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
        public ActionResult Edit(Building newBuilding, HttpPostedFileBase Image
            , List<HttpPostedFileBase> Images)  
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
                    bool updateImage = buildingService.UpdateImage(newBuilding, Image, Images);
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

        // GET: Admin/Building/Delete/5
        public ActionResult Delete(int id)
            {
                return View();
            }


        
        // POST: Admin/Building/Delete/5
        [HttpPost]
        public ActionResult Delete(string id)
        {
            try
            {
                // TODO: Add delete logic here
                bool IsDeleted = buildingService.DeleteBuilding(id);
                if (IsDeleted)
                {
                    TempData["DeleteSuccess"] = "Xóa thông tin thành công";
                }
                else
                {
                    TempData["DeleteError"] = "Xóa thông tin thất bại hoặc không tìm thấy thông tin";
                }

                return View();
            }
            catch
            {
                return RedirectToAction("Create");
            }
        }
    }
}
