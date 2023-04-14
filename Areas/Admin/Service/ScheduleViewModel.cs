using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuildingDemo.Models;

namespace BuildingDemo.Areas.Admin.Service
{
    public class ScheduleViewModel
    {
        public Schedule Schedule { get; set; }
        public string BuildingName { get; set; }
        public string EmployeeName { get; set; }
    }
}