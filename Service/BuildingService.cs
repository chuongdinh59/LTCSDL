using BuildingDemo.Models;
using BuildingDemo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildingDemo.Service
{
    public class BuildingService
    {
        private BuildingRepository buildingRepository = new BuildingRepository();

        public IEnumerable<Building> testService()
        {
            return buildingRepository.test();
        }
        public IEnumerable<Building> getTop(int x)
        {
            return buildingRepository.getTop(x);
        }
    }
}