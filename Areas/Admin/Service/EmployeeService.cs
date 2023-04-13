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
                    target.Email = employee.Email;

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
                    foreach (var buildingId in buildingids)
                    {

                        if (!currBuildingIDOfEmpl.Contains(buildingId))
                        {
                            ManagementBuilding mb = new ManagementBuilding {
                                EmployeeID = id,
                                BuildingID = buildingId
                            };
                            db.ManagementBuildings.Add(mb);
                        }
                        else
                        {
                            ManagementBuilding item = db.ManagementBuildings
                               .FirstOrDefault(mbx => mbx.BuildingID == buildingId );
                            if (item != null)
                            {
                                db.ManagementBuildings.Remove(item);
                            }
                        }
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