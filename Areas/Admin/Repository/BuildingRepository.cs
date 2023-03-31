using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuildingDemo.Models;

namespace BuildingDemo.Areas.Admin.Repository
{
    public class BuildingRepository
    {
        private static BuildingDB db = new BuildingDB();

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
        public IEnumerable<Building> getAll()
        {
            return db.Buildings.ToList();
        }
        public Building findByID(string id)
        {
            return db.Buildings.Find(id);
        }
    }
}