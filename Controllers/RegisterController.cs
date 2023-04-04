using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildingDemo.Service;
using BuildingDemo.Models;

namespace BuildingDemo.Controllers
{
    public class RegisterController : Controller
    {
        private AccountService accountService = new AccountService();
        public ActionResult Register()
        {
            return View();
        }
        //public JsonResult IsUsernameAvailable(string username)
        //{
        //    bool isAvailable = true;

        //    // kiểm tra username đã tồn tại trong cơ sở dữ liệu hay chưa
        //    var check = accountService.getAccount().FirstOrDefault(s => s.Username == username);

        //    // nếu có, đặt isAvailable = false
        //    if(check != null)
        //    {
        //        isAvailable = false;
        //    }

        //    return Json(isAvailable, JsonRequestBehavior.AllowGet);
        //}

        [HttpPost]
        public ActionResult Register(Account account)
        {
            if (accountService.Check(account))
            {
                var acc = accountService.CreateAccount(account);
                if (acc != null)
                {
                    TempData["CreatedSuccess"] = "Đăng ký thành công!";
                    ViewBag.Error = "";
                    return View(acc);
                }
            }
            else
            {
                TempData["UsernameExists"] = "username đã tồn tại!";
                ViewBag.Error = "Đăng ký không thành công!";
            }
            return View();
        }

    }
}