using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuildingDemo.Models;

namespace BuildingDemo.Areas.Admin.Service
{
    public class ScheduleViewModelCustomer
    {
        public Schedule Schedule { get; set; }
        public string BuildingName { get; set; }
        public string CustomerName { get; set; }

        public bool Session { get; set; }
        public bool IsValid { get; set; }
    }
}