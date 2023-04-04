using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildingDemo.Areas.Admin.Service;
using BuildingDemo.Models;

namespace BuildingDemo.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        private AccountService accountService = new AccountService();
        private RoleService roleService = new RoleService();
        // GET: Admin/Account
        public ActionResult Index()
        {
            List<Account> accounts = accountService.getAll();
            return View(accounts);
        }

        // GET: Admin/Account/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Account/Create
        public ActionResult Create()
        {
            List<Role> roles = roleService.getAll();
            return View(roles);
        }

        // POST: Admin/Account/Create
        [HttpPost]
        [Obsolete]
        public ActionResult Create(Account account)
        {
            try
            {
                // TODO: Add insert logic here
                bool result = accountService.CreateAccount(account);
                if (result)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["SavevError"] = "Fail to save the account record.";
                    return RedirectToAction("Create");
                }
            }
            catch
            {
                return View();
            }
        }
        private ActionResult View(List<Role> roles, Account account)
        {
            ViewBag.Roles = roles;
            ViewBag.Account = account;
            return View();
        }
        // GET: Admin/Account/Edit/5
        public ActionResult Edit(int id)
        {
            List<Role> roles = roleService.getAll();
            Account account = accountService.findByID(id);
            return View(roles, account);
        }

        // POST: Admin/Account/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Account account)
        {
            try
            {
                bool isUpdated = accountService.UpdateAccount(account);
                if (isUpdated)
                {
                    TempData["SaveSuccess"] = "Thay đổi thông tin thành công";
                }
                else
                {
                    TempData["SaveError"] = "Thay đổi thông tin không thành công";
                }
                return RedirectToAction("Edit");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Account/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Account/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                bool IsDeleted = accountService.DeleteAccount(id);
                // TODO: Add delete logic here
                if (IsDeleted)
                {
                    TempData["DeleteSuccess"] = "Xóa thông tin thành công";
                }
                else
                {
                    TempData["DeleteError"] = "Xóa thông tin thất bại hoặc không tìm thấy thông tin";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
