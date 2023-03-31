using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuildingDemo.Areas.Admin.Repository;
using BuildingDemo.Models;

namespace BuildingDemo.Areas.Admin.Service
{
    public class BuildingTypeService
    {
        private BuildingTypeRepository buildingTypRepository = new BuildingTypeRepository();

        public IEnumerable<BuildingType> getAll ()
        {
            return buildingTypRepository.getAll();
        }
    }
}