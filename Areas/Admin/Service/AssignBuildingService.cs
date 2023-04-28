using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuildingDemo.Models;

namespace BuildingDemo.Areas.Admin.Service
{
    public class AssignBuildingService
    {
        private BuildingDB db = new BuildingDB();

        public List<ManagementBuilding> getAll()
        {
            return db.ManagementBuildings.ToList();
        }
        public HashSet<Schedule> GetScheduleByEmployee(int EmployeeID)
        {
            try
            {
                Employee employee = db.Employees.Find(EmployeeID);
                if (employee == null) return new HashSet<Schedule>();
                return (HashSet<Schedule>)employee.Schedules;
            }
            catch
            {
                return new HashSet<Schedule>();
            }
        }
    }
}