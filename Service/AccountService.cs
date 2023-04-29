using BuildingDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildingDemo.Service
{
    public class AccountService
    {
        BuildingDB db = new BuildingDB();
        public Account CreateAccount(Account account)
        {
            try
            {
                account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
                account.RoleID = 3;
                //db.Configuration.ValidateOnSaveEnabled = false;
                db.Accounts.Add(account);
                db.SaveChanges();
                Account account1 = db.Accounts.SingleOrDefault(a => a.Username == account.Username); // Retrieve the account entity from the database
                Customer customer = new Customer();
                customer.AccountID = account1.ID;
                db.Customers.Add(customer);
                db.SaveChanges();
                return account;
            }
            catch
            {
                return null;
            }
        }
        public bool Check(Account account)
        {
            try
            {
                var check = db.Accounts.FirstOrDefault(s => s.Username == account.Username);
                if (check == null)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public List<Account> getAccount()
        {
            return db.Accounts.ToList();
        }
        public Account findByID(int id)
        {
            return db.Accounts.Find(id);
        }
    }
}