using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildingDemo.Service;
using BuildingDemo.Models;

namespace BuildingDemo.Controllers
{
    public class LoginController : Controller
    {
        private AccountService accountService = new AccountService();
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
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