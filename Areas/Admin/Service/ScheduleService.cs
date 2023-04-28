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
        public bool CreateSchedule(string BuildingID, DateTime Time, bool Session, int AccountID)
        {
            try
            {
                Customer customer = db.Customers.FirstOrDefault(c => c.AccountID == AccountID);
                if (customer == null) return false;
                Schedule schedule = new Schedule();
                schedule.BuildingID = BuildingID;
                schedule.Time = Time;
                schedule.Session = Session;
                schedule.IsResolve = false;
                schedule.CustomerID = customer.ID;
                db.Schedules.Add(schedule);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<Schedule> GetBuildingsNotResolve()
        {
            return db.Schedules.Where(s => s.IsResolve == false).ToList();
        }

        public List<Schedule> GetBuildingsResolveAndIsTarget(Building building)
        {
            List<Schedule> schedules = db.Schedules
                        .Where(s => s.IsResolve == true && s.BuildingID == building.ID)
                        .ToList();
            return schedules;
        }
        public List<Schedule> FindAll()
        {
            return db.Schedules.ToList();
        }
        public string CreateSchedule(string BuildingID, int? EmployeeID, DateTime? DateAppointment, bool? Session)
        {
            try
            {
               if (!checkIsValid(-1,BuildingID, EmployeeID, DateAppointment, Session))
                {
                    return "Không khả dụng để tạo lịch";
                }
                // Nếu lịch trình mới không trùng ngày và thứ với bất kỳ lịch trình nào đã có, bạn có thể thêm lịch trình mới và trả về true.

                Schedule schedule = new Schedule();
                schedule.BuildingID = BuildingID;
                schedule.EmployeeID = EmployeeID;
                schedule.Time = DateAppointment;
                schedule.Session = Session;
                db.Schedules.Add(schedule);
                db.SaveChanges();
                return "success";
            }
            catch (Exception e)
            {
                return "Có lỗi xảy ra khi thêm lịch";
            }
        }
        
        
        public bool checkIsValid(int ScheduleID, string BuildingID, int? EmployeeID, DateTime? DateAppointment, bool? Session)
        {
            //List<Schedule> employeeSchedules = db.Schedules.Where(s => s.ID != ScheduleID &&  s.EmployeeID == EmployeeID && s.Time == DateAppointment && s.Session == Session).ToList();

            //if (employeeSchedules.Any())
            //{
            //    //return "Nhân viên bị trùng lịch";
            //    return false;
            //}

            List<Schedule> schedules = db.Schedules.Where(s => s.ID != ScheduleID &&  s.BuildingID == BuildingID && s.Time == DateAppointment && s.Session == Session).ToList();

            if (schedules.Any())
            {
                //return "Nhà này đã tồn tại lịch xem rồi";
                return false;
            }
            return true;
        }
        
        public Schedule FindByID(int id)
        {
            return db.Schedules.Find(id);
        }

        public bool changeStatusIsResolve(int ScheduleID)
        {

            try
            {
                Schedule target = db.Schedules.Find(ScheduleID);

                if (target == null)
                {
                    return false;
                }
                target.IsResolve = true;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;   
            }
        }
        

        public bool AddEmployeeToSchedule(int EmployeeID, int ScheduleID)
        {
            try
            {
                // Trước khi add thì kiểm tra xem employee đã có lịch vào Time của shedule chưa
                Schedule schedule = db.Schedules.Find(ScheduleID);
                Employee employee = db.Employees.Find(EmployeeID);

                // Check if the employee is already scheduled at the same time as the specified schedule
                bool isConflict = employee.Schedules.Any(s => s.Time == schedule.Time && s.ID != ScheduleID && s.Session == schedule.Session);
                if (isConflict)
                {
                    return false; // There is a scheduling conflict
                }
                if (schedule != null) schedule.EmployeeID = EmployeeID;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool EditSchedule(int id, DateTime? DateAppointment, bool? Session)
        {
            try
            {
                Schedule schedule = db.Schedules.Find(id);
                if (DateAppointment != null)
                {
                    schedule.Time = DateAppointment;
                }
                if (Session != null)
                {
                    schedule.Session = Session;
                }
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    
    }
}