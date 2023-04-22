﻿using BuildingDemo.Areas.Admin.Controllers;
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
        public bool save(Building building)
        {
            try
            {
                db.Buildings.Add(building);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // handle any exceptions here
                return false;
            }
        }
        public bool update()
        {
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // handle any exceptions here
                return false;
            }
        }
        public List<Building> GetAll()
        {
            return db.Buildings.ToList();
        }
        public Building FindByID(string id)
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
                    b.Address = building.Address;
                    b.Area = building.Area;
                    b.PurchasePrice = building.PurchasePrice;
                    b.NumFloors = building.NumFloors;
                    b.BuildingTypeID = building.BuildingTypeID;
                    b.YearBuild = building.YearBuild;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<Building> GetBuildingFromCustomer(Customer customer)
        {
            return customer.Buildings.ToList();
        }
    }
}