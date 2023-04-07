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

    }
}