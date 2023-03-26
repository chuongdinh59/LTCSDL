using BuildingDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildingDemo.Repository
{
    public class BuildingRepository
    {

        private static BuildingDB db = new BuildingDB();
        public IEnumerable<Building> test()
        {
            return db.Buildings.ToList();
        }
    }
}