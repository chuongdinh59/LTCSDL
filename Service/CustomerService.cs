using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuildingDemo.Models;

namespace BuildingDemo.Service
{
    public class CustomerService
    {
        BuildingDB db = new BuildingDB();
        public List<Customer> GetAll()
        {
            return db.Customers.ToList();
        }
        public Customer FindByAccountID(int accountID)
        {
            Customer customer = db.Customers.FirstOrDefault(c => c.AccountID == accountID);

            return customer;
        }



        public HashSet<Schedule> GetMySchedule(int accountID)
        {
            Customer customer = FindByAccountID(accountID);
            var sortedSchedules = customer.Schedules.OrderBy(s => s.Time);
            return new HashSet<Schedule>(sortedSchedules);
        }
        public bool EditInfoCustomer(Customer customer, int id, string email)
        {
            try
            {
                using (var db = new BuildingDB())
                {
                    Customer cus = db.Customers.FirstOrDefault(c => c.AccountID == id);
                    cus.Account.Email = email;
                    cus.Name = customer.Name;
                    cus.Address = customer.Address;
                    cus.Phone = customer.Phone;
                    cus.Note = customer.Note;
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

    }
}