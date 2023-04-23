using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildingDemo.Service;
using BuildingDemo.Models;
using BuildingDemo.Filter;

namespace BuildingDemo.Controllers
{
    public class LoginController : Controller
    {
        private AccountService accountService = new AccountService();
        [HttpGet]
        [AnonymousFilter]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AnonymousFilter]
        public ActionResult Login(Account account)
        {

            var user = accountService.getAccount().SingleOrDefault(u => u.Username == account.Username);
            if (user != null)
            {
                bool passwordMatches = BCrypt.Net.BCrypt.Verify(account.Password, user.Password);
                if (passwordMatches)
                {
                    ViewBag.Error = "";
                    Session["ID"] = user.ID;
                    Session["Username"] = user.Username;
                    switch (user.RoleID)
                    {
                        case 1:
                            return RedirectToAction("Index", "Admin");
                        case 2:
                            return RedirectToAction("Index", "Property");
                        case 3:
                            return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    // Đăng nhập thất bại
                    ViewBag.Error = "username hoặc mật khẩu không đúng!";
                }
            }
            return View();
        }

    }
} 