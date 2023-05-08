using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuildingDemo.Areas.Admin.Controllers;
using BuildingDemo.Models;

namespace BuildingDemo.Areas.Admin.Service
{
    public class AccountService
    {
        private BuildingDB db = new BuildingDB();
        public List<Account> getAll()
        {
            //using (BuildingDB db = new BuildingDB())
            //{
                return db.Accounts.ToList();
            //}
        }

        public Account findByID(int id)
        {
            return db.Accounts.Find(id);
        }
        [Obsolete]
        public bool CreateAccount(Account account)
        {
            try
            {
                if (db.Accounts.FirstOrDefault(x => x.Username == account.Username) != null)
                {
                    return false;
                }
                account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
                db.Accounts.Add(account);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteAccount(int id)
        {
            try
            {
                Account target = db.Accounts.Find(id);
                if (target != null)
                {
                    db.Accounts.Remove(target);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateAccount(Account account)
        {
            try
            {
                Account target = db.Accounts.Find(account.ID);
                if (target == null)
                {
                    return false;
                }
                if (account.Password != target.Password)
                {
                    target.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
                }
                target.RoleID = account.RoleID;
                db.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }
    }
}