using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuildingDemo.Areas.Admin.Controllers;
using BuildingDemo.Models;

namespace BuildingDemo.Areas.Admin.Service
{
    public class EmployeeService
    {
        public List<Employee> getAll ()
        {
            using (BuildingDB db = new BuildingDB())
            {
                return db.Employees.ToList();
            }
        }

        public List<Employee> GetEmployeeMangement(Building building)
        {
            try
            {
                using (BuildingDB db = new BuildingDB())
                {
                    var employees = db.Employees
                        .Join(db.ManagementBuildings, e => e.ID, m => m.EmployeeID, (e, m) => new { Employee = e, Management = m })
                        .Join(db.Buildings, em => em.Management.BuildingID, b => b.ID, (em, b) => new { Employee = em.Employee, Building = b })
                        .Where(x => x.Building.ID == building.ID)
                        .Select(x => x.Employee)
                        .ToList();

                    return employees;
                }
              
            }
            catch
            {
                return null;
            }
        }
        public Employee findByID(int id)
        {
            using (BuildingDB db = new BuildingDB())
            {
                return db.Employees.Find(id);
            }
        }
        [Obsolete]
        public bool CreateEmployee(Employee employee, HttpPostedFileBase Avatar)
        {
            try
            {
                using (BuildingDB db = new BuildingDB())
                {
                    Employee dup = db.Employees
                        .FirstOrDefault(e => e.Name == employee.Name && e.Phone == employee.Phone);

                    // If there is a duplicate, return false
                    if (dup != null)
                    {
                        return false;
                    }
                    if (db.Accounts.Find(employee.AccountID).RoleID != 2)
                    {
                        return false;
                    }
                        // Check if Employee exists in any Account record
                        if (db.Accounts.Find(employee.AccountID) == null )
                    {
                        return false;
                    }
                    // dup accout id 
                    if (db.Employees
                        .FirstOrDefault(e => e.AccountID == employee.AccountID) != null)
                    {
                        return false;
                    }
                    if (Avatar != null)
                    {
                        employee.Avatar = CloudinaryController.UploadImage(Avatar);
                    }
                    db.Employees.Add(employee);
                    db.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        [Obsolete]
        public bool UpdateEmployee(Employee employee, HttpPostedFileBase Avatar)
        {
            try
            {
                using ( BuildingDB db = new BuildingDB())
                {
                    Employee target = db.Employees.Find(employee.ID);
                    target.Address = employee.Address;
                    target.Phone = employee.Phone;
                    if (Avatar != null)
                    {
                        target.Avatar = CloudinaryController.UploadImage(Avatar);
                    }
                    db.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool DeleteEmploye(int id)
        {
            try
            {
                using(BuildingDB db = new BuildingDB())
                {
                    Employee employee = db.Employees.Find(id);
                    if (employee != null)
                    {
                        db.Accounts.Remove(employee.Account);
                        db.Employees.Remove(employee);
                    }
                    db.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool AssignBuilding( int id, List<String> buildingids)
        {
            try
            {
                using (BuildingDB db = new BuildingDB())
                {
                    //Employee employee = db.Employees.Find(id);
                    //if (employee == null)
                    //    return false;
                    List<string> currBuildingIDOfEmpl = db.ManagementBuildings
                                                        .Where(mb => mb.EmployeeID == id)
                                                        .Select(mb => mb.BuildingID).ToList();
                    // Đi delete những item có EmployeeID = id
                    // Remove the existing building assignments that are not in the new list
                    foreach (var mb in db.ManagementBuildings.Where(mb => mb.EmployeeID == id ))
                    {
                        db.ManagementBuildings.Remove(mb);
                    }

                    foreach (var buildingId in buildingids)
                    {
                            ManagementBuilding mb = new ManagementBuilding {
                                EmployeeID = id,
                                BuildingID = buildingId
                            };
                            mb.IsSuccess = false;
                            db.ManagementBuildings.Add(mb);
                    }
                    db.SaveChanges();
                }
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}