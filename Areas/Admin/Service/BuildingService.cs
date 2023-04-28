using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuildingDemo.Areas.Admin.Controllers;
using BuildingDemo.Areas.Admin.Repository;
using BuildingDemo.Models;

namespace BuildingDemo.Areas.Admin.Service
{
    public class BuildingService
    {
        private BuildingRepository buildingRepository = new BuildingRepository();
        private BuildingDB db = new BuildingDB();

        public List<Building> GetBuildingAssign()
        {
            try
            {
                List<string> buildingSuccess = db.ManagementBuildings.
                    Where(mb => mb.IsSuccess == true).Select(mb => mb.BuildingID).ToList();
                List<Building> buildings = db.Buildings
                          .Where(b => !buildingSuccess.Contains(b.ID))
                          .ToList();
                return buildings;
            }
            catch
            {
                return null;
            }
        }
        public bool save(Building building)
        {
            return buildingRepository.save(building);
        }
        public bool update()
        {
            return buildingRepository.update();
        }
        public IEnumerable<Building> getAll()
        {
            return buildingRepository.getAll();
        }
        public Building findByID(string id)
        {
            return db.Buildings.Find(id);
        }
        public bool EditInfoBuilding(Building building)
        {
            try
            {
                using (var db = new BuildingDB())
                {
                    Building b = db.Buildings.Find(building.ID);
                    b.Bath = building.Bath;
                    b.Bed = building.Bed;
                    b.Name = building.Name;
                    b.NumFloors = building.NumFloors;
                    b.BuildingTypeID = building.BuildingTypeID;
                    b.YearBuild = building.YearBuild;
                    db.SaveChanges();
                }
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        [Obsolete]
        public bool UpdateImage(Building building, HttpPostedFileBase Image, List<HttpPostedFileBase> Images )
        {
            try
            {
                using (var db = new BuildingDB())
                {
                    Building b = db.Buildings.Find(building.ID);

                    // Xóa hình cũ trên cloudinary
                    //if (b.Image != null)
                    //{
                    //    CloudinaryController.DeleteImage(b.Image);
                    //}
                    if (Image != null)
                    {
                        b.Image = CloudinaryController.UploadImage(Image);
                    }

                    if (Images.Count > 0 && Images.First() != null)
                    {

                        var imagesToRemove = b.Images.ToList();
                        foreach (var img in imagesToRemove)
                        {
                            db.Images.Remove(img);
                        }
                        for (int i = 0; i < Images.Count; i++)
                        {
                            Image img = new Image();
                            img.BuildingID = b.ID;
                            img.URL = CloudinaryController.UploadImage(Images[i]);
                            b.Images.Add(img);
                        }
                    }
                    db.SaveChanges();

                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteBuilding(string id)
        {
            try
            {
                using (BuildingDB db = new BuildingDB())
                {
                    Building building = db.Buildings.Find(id);
                    if (building != null)
                    {
                        db.Buildings.Remove(building);
                        db.SaveChanges();
                    }
                    else
                    {
                        // The building with the specified ID was not found
                        throw new Exception($"Building with ID {id} not found.");
                    }

                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Building> GetBuildingsNotResolve()
        {
            return db.Buildings.Where(b => b.IsResolve == false).ToList();

        }
        public bool chageResolve(String id)
        {
            try {
                Building target = db.Buildings.Find(id);
                if (target == null) return false;
                target.IsResolve = true;
                EmailController.SendEmail
                    ("chuongdinh2202@gmail.com",
                    "Nhà của bạn đã được phê duyệt",
                    "Thông báo duyệt thành công nhà " + target.Name);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
   
}