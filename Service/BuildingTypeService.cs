using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuildingDemo.Models;

namespace BuildingDemo.Service
{
    public class BuildingTypeService
    {

        private BuildingDB db = new BuildingDB();

        public List<BuildingType> getAll ()
        {
            return db.BuildingTypes.ToList();
        }
    }
}