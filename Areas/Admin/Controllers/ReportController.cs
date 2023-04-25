using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuildingDemo.Areas.Admin.Service;

namespace BuildingDemo.Areas.Admin.Controllers
{
    public class ReportController : Controller
    {
        private ReportService reportService = new ReportService();
        // GET: Admin/Report
        public ActionResult Index()
        {
            double TotalProhibit = reportService.GetTotalProhibit();
            int ScheduleNumber = reportService.GetCountOrder();
            int CustomerNumber = reportService.GetCountCustomer();
            int BuildingNumber = reportService.GetCountBuilding();
            int BuildingCustomer = reportService.GetCustomerBuilding();
            int BuildingSystem = reportService.GetSystemBuilding();

            List<ReportEmployeeView> reportEmployeeViews = reportService.GetEmployeeNumberSuccess();

            int[] NumberOfOrderSuscessList = reportEmployeeViews.Select(r => r.numberOfOrderSuscess).ToArray();
            string[] NameOfEmployee = reportEmployeeViews.Select(r => r.employee.Name).ToArray();

            List<ReportScheduleView> reportScheduleViews = reportService.GetReportScheduleViews();
            int[] ReportScheduleViewsTarget = new int[7];
            string[] weekdays = new[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            for (int i = 0; i < weekdays.Length; i++)
            {
                ReportScheduleViewsTarget[i] = reportScheduleViews.FirstOrDefault(r => r.day == weekdays[i])?.ScheduleCount ?? 0;
            }
            return View(TotalProhibit, ScheduleNumber, CustomerNumber, 
                BuildingNumber, BuildingCustomer, BuildingSystem, reportEmployeeViews, NumberOfOrderSuscessList, NameOfEmployee, ReportScheduleViewsTarget);
        }
        private ActionResult View(double TotalProhibit , int ScheduleNumber,
                        int CustomerNumber, int BuildingNumber, int BuildingCustomer,
                        int BuildingSystem, List<ReportEmployeeView> reportEmployeeViews ,
                         int[] NumberOfOrderSuscessList , string[] NameOfEmployee, int[] ReportScheduleViewsTarget)
        {
            ViewBag.TotalProhibit = TotalProhibit;
            ViewBag.BuildingCustomer = BuildingCustomer;
            ViewBag.BuildingSystem = BuildingSystem;
            ViewBag.ScheduleNumber = ScheduleNumber;
            ViewBag.CustomerNumber = CustomerNumber;
            ViewBag.BuildingNumber = BuildingNumber;
            ViewBag.reportEmployeeViews = reportEmployeeViews;
            ViewBag.NumberOfOrderSuscessList = NumberOfOrderSuscessList;
            ViewBag.NameOfEmployee = NameOfEmployee;
            ViewBag.ReportScheduleViewsTarget = ReportScheduleViewsTarget;
            return View();
        }
    }
}