using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuildingDemo.Models;

namespace BuildingDemo.Areas.Admin.Repository
{
    public class BuildingTypeRepository
    {
        private static BuildingDB db = new BuildingDB();
        public IEnumerable<BuildingType> getAll ()
        {
            return db.BuildingTypes.ToList();
        }
    }
}