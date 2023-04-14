using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuildingDemo.Models;

namespace BuildingDemo.Areas.Admin.Service
{
    public class ScheduleService
    {
        private BuildingDB db = new BuildingDB();

        public List<Schedule> FindAll()
        {
            return db.Schedules.ToList();
        }
        public string CreateSchedule(string BuildingID, int? EmployeeID, DateTime? DateAppointment, bool? Session)
        {
            try
            {
                List<Schedule> employeeSchedules = db.Schedules.Where(s => s.EmployeeID == EmployeeID && s.Time == DateAppointment && s.Session == Session).ToList();

                if (employeeSchedules.Any())
                {
                    return "Nhân viên bị trùng lịch";
                }

                List<Schedule> schedules = db.Schedules.Where(s => s.BuildingID == BuildingID && s.Time == DateAppointment && s.Session == Session).ToList();

                if (schedules.Any())
                {
                    return "Nhà này đã tồn tại lịch xem rồi";
                }
                // Nếu lịch trình mới không trùng ngày và thứ với bất kỳ lịch trình nào đã có, bạn có thể thêm lịch trình mới và trả về true.

                Schedule schedule = new Schedule();
                schedule.BuildingID = BuildingID;
                schedule.EmployeeID = (int)EmployeeID;
                schedule.Time = DateAppointment;
                schedule.Session = Session;
                db.Schedules.Add(schedule);
                db.SaveChanges();
                return "success";
            }
            catch(Exception e)
            {
                return "Có lỗi xảy ra khi thêm lịch"; 
            }
        }
    }
}