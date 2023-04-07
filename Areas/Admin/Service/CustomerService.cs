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
                    target.Email = customer.Email;
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
            catch
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
                    if (db.Accounts.Find(customer.AccountID) == null)
                    {
                        return false;
                    }
                    if(Avatar != null)
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