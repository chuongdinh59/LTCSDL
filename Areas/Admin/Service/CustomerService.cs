using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuildingDemo.Areas.Admin.Controllers;
using BuildingDemo.Areas.Admin.Repository;
using BuildingDemo.Models;

namespace BuildingDemo.Areas.Admin.Service
{
    public class CustomerService
    {
    public List<Customer> getAll ()
        {
            using(BuildingDB db = new BuildingDB())
            {
                return db.Customers.ToList();
            }
        }
        public Customer findByID(int id)
        {
            using (BuildingDB db = new BuildingDB())
            {
                return db.Customers.Find(id);
            } 
        }

        [Obsolete]
        public bool UpdateInfoCustomer(Customer customer , HttpPostedFileBase Avatar)
        {
            try
            {
                using (BuildingDB db = new BuildingDB())
                {
                    Customer target = db.Customers.Find(customer.ID);
                    target.Address = customer.Address;
                    target.Name = customer.Name;
                    target.Phone = customer.Phone;
                    if(Avatar != null)
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

        public bool DeleteCustomer(int id)
        {
            try
            {
                using (BuildingDB db = new BuildingDB())
                {
                    Customer customer = db.Customers.Find(id);
                    if (customer != null)
                    {
                        // hot fix 5
                        foreach (var building in customer.Buildings.ToList())
                        {
                            foreach (var schedule in building.Schedules.ToList())
                            {
                                db.Schedules.Remove(schedule);
                            }
                            db.Buildings.Remove(building);
                        }

                        foreach (var schedule in customer.Schedules.ToList())
                        {
                            db.Schedules.Remove(schedule);
                        }
                        db.Accounts.Remove(customer.Account);
                        db.Customers.Remove(customer);
                        db.SaveChanges();
                    }
                    else
                    {
                        // The building with the specified ID was not found
                        throw new Exception($"Building with ID {id} not found.");
                    }

                }
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        [Obsolete]
        public bool CreateCustomer(Customer customer, HttpPostedFileBase Avatar)
        {
            try
            {
                using (BuildingDB db = new BuildingDB())
                {
                    
                    if (db.Customers.SingleOrDefault(c => c.Name == customer.Name) != null)
                    {
                        return false;
                    }
                    Account account = db.Accounts.Find(customer.AccountID);
                    if (account == null || account.RoleID != 3)
                    {
                        return false;
                    }
                    // dup account cho 2 người
                    if (db.Customers
                        .FirstOrDefault(e => e.AccountID == customer.AccountID) != null)
                    {
                        return false;
                    }
                    if (Avatar != null)
                    {
                        customer.Avatar = CloudinaryController.UploadImage(Avatar);
                    }
                    db.Customers.Add(customer);
                    db.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
}
}