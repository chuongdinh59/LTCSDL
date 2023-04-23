using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildingDemo.Filter;

namespace BuildingDemo.Controllers
{
    public class BookedController : Controller
    {
        // GET: Booked
        [AuthenticationFilter]
        public ActionResult Index()
        {
            return View();
        }
    }
}