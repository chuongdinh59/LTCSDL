using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuildingDemo.Models;

namespace BuildingDemo.Areas.Staff.Service
{
    public class StaffService
    {
        BuildingDB db = new BuildingDB();

        public List<Building> GetManagementBuilding(int AccountID)
        {
            try
            {
                Employee employee = db.Employees.FirstOrDefault(c => c.AccountID == AccountID);
                List<ManagementBuilding> managementBuildings =
                    db.ManagementBuildings.Where(m => m.EmployeeID == employee.ID && m.IsSuccess == false).ToList();

                List<Building> buildings = new List<Building>();
                foreach (ManagementBuilding management in managementBuildings)
                {
                    if (management.Building != null)
                    {
                        buildings.Add(management.Building);
                    }
                }
                return buildings;
            }
            catch
            {
                return null;
            }
        }

        public HashSet<Schedule> GetScheduleByEmployee(int AccountID)
        {
            try
            {
                Employee employee = db.Employees.FirstOrDefault(c => c.AccountID == AccountID);
                if (employee == null)  return new HashSet<Schedule>();
                return (HashSet<Schedule>)employee.Schedules;
            }
            catch
            {
                return new HashSet<Schedule>();
            }
        }
        public bool HandleDone(int AccountID, string BuildingID)
        {
            try
            {
                Employee employee = db.Employees.FirstOrDefault(c => c.AccountID == AccountID);
                if (employee == null) return false;

                // Step 1: Get the existing management record that matches the AccountID and BuildingID
                ManagementBuilding existingManagement = db.ManagementBuildings.FirstOrDefault(m => m.EmployeeID == employee.ID && m.BuildingID == BuildingID);

                // Step 2: Update the existing management record to set IsSuccess to true
                if (existingManagement != null)
                {
                    existingManagement.IsSuccess = true;
                }

                // Step 3: Remove all other management records that have a matching BuildingID
                List<ManagementBuilding> otherManagement = db.ManagementBuildings.Where(m => m.BuildingID == BuildingID && m.ID != existingManagement.ID).ToList();
                if (otherManagement.Count > 0)
                {
                    db.ManagementBuildings.RemoveRange(otherManagement);
                }
                db.SaveChanges();
                return true;
                // Save the changes to the database
            }
            catch
            {
                return false;
            }
        }
    }
}