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
            account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
            account.RoleID = 3;
            db.Configuration.ValidateOnSaveEnabled = false;
            db.Accounts.Add(account);
            db.SaveChanges();
            return account;
        }
        public bool Check(Account account)
        {
            var check = db.Accounts.FirstOrDefault(s => s.Username == account.Username);
            if (check == null)
            {
                return true;
            }
            return false;
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