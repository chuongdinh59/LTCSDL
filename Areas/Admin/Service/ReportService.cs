using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Globalization;
using System.Linq;
using System.Web;
using BuildingDemo.Models;

namespace BuildingDemo.Areas.Admin.Service
{
    public class ReportService
    {

        private BuildingDB db = new BuildingDB();
        public double GetTotalProhibit()
        {
            var buildings = db.Buildings.Where(b => b.IsPay == true);
            double total = 0;
            foreach (var building in buildings)
            {
                if (building.ID.StartsWith("KG") )
                {
                    total += (double)building.PurchasePrice * 0.02;
                }
                else 
                {
                    total += (double)building.PurchasePrice * 0.01;
                }
            }
            return total;
        }

        public int GetCountOrder() // Schedule
        {
            return db.Schedules.Count(s => s.IsResolve == true);
        }
        public int GetCountCustomer()
        {
            return db.Customers.Count();
        }

        public int GetCountBuilding()
        {
            return db.Buildings.Count();
        }

        public int GetSystemBuilding()
        {
            return db.Buildings.Count(b => b.ID.StartsWith("HT"));
        }

        public int GetCustomerBuilding()
        {
            return db.Buildings.Count(b => b.ID.StartsWith("KG"));

        }

        public List<ReportEmployeeView> GetEmployeeNumberSuccess()
        {
            var report = db.ManagementBuildings
                .GroupBy(m => m.EmployeeID)
                .Select(g => new ReportEmployeeView {
                    employee = g.FirstOrDefault().Employee,
                    numberOfOrderSuscess = g.Count(m => m.IsSuccess == true)
                })
                .OrderByDescending(r => r.numberOfOrderSuscess)
                .Take(5
                )
                .ToList();
            return report;
        }

        public List<ReportScheduleView> GetReportScheduleViews()
        {
            var reportScheduleViews = db.Schedules
             .GroupBy(s => SqlFunctions.DateName("weekday", s.Time))
             .Select(g => new ReportScheduleView {
                 day = g.Key,
                 ScheduleCount = g.Count()
             })
             .ToList();
            return reportScheduleViews;
        }
    }

}