using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildingDemo.Filter;

namespace BuildingDemo.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Logout
        [AuthenticationFilter]
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}