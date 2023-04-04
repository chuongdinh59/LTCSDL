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

        private static BuildingDB db = new BuildingDB();
        internal object Accounts;

        public List<Building> getAll()
        {
            return db.Buildings.ToList();
        }
        public List<Building> getTop(int x)
        {
            return db.Buildings.Take(x).ToList();
        }
    }
}