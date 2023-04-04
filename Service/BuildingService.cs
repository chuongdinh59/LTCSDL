using BuildingDemo.Areas.Admin.Controllers;
using BuildingDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BuildingDemo.Service
{
    public class BuildingService
    {
        //private BuildingRepository buildingRepository = new BuildingRepository();

        //public IEnumerable<Building> testService()
        //{
        //    return buildingRepository.test();
        //}
        //public IEnumerable<Building> getTop(int x)
        //{
        //    return buildingRepository.getTop(x);
        //}

        private  BuildingDB db = new BuildingDB();
 

        public List<Building> getAll()
        {
            return db.Buildings.ToList();
        }
        public List<Building> getTop(int x)
        {
            return db.Buildings.Take(x).ToList();
        }

        [Obsolete]
        public bool CreateBuilding(Building building, HttpPostedFileBase Image)
        {
            try
            {
                Guid uuid = Guid.NewGuid();
                string ID = "KG-" + uuid.ToString();
                building.ID = ID;
                building.IsResolve = false;
                building.CustomerID = 43;
                if (Image != null) // Đoạn này kiểm tra có hình không 
                {
                    building.Image = CloudinaryController.UploadImage(Image);
                }
                db.Buildings.Add(building);
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