using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Data.Seeds
{
    public static class DbSeedExtensions
    {
        public static void InsertDoctor(this ModelBuilder builder)
        {
            IList<Doctor> doctors = new List<Doctor>();
            doctors.Add(new Doctor() {Id=1, Name = "علی", Family = "محسنی", Expertise = "قلب",JobAddress="address1",Phone="0912457589", AppointmentInterval=30 });
            doctors.Add(new Doctor() {Id=2,Name = "پویا", Family = "امامی", Expertise = "پوست",JobAddress= "address2",Phone="0912358974", AppointmentInterval =15});
            doctors.Add(new Doctor() {Id=3, Name = "اکرم", Family = "نادری", Expertise = "داخلی",JobAddress="address3",Phone="0912763548", AppointmentInterval=20 });

            builder.Entity<Doctor>().HasData(doctors);
            
        }
        public static void InsertUser(this ModelBuilder builder)
        {
            IList<User> users = new List<User>();
            users.Add(new User() {Id=1, Name = "رضا", Family = "محسنی", NationalCode = "0014725821", UserName = "علی", Password = "0912457589" });
            users.Add(new User() {Id=2, Name = "پوریا", Family = "امامی", NationalCode = "0032165498", UserName = "پویا", Password = "0912457589" });
            users.Add(new User() {Id=3, Name = "مینا", Family = "نادری", NationalCode = "0085296345", UserName = "اکرم", Password = "0912457589" });

            builder.Entity<User>().HasData(users);

        }
        public static void InsertWorkingHour(this ModelBuilder builder)
        {
            IList<WorkingHour> WorkHour = new List<WorkingHour>();
            WorkHour.Add(new WorkingHour() { Id = 1, FromWorkHour = new System.TimeSpan(9,30,0), ToWorkHour =new System.TimeSpan(16,0,0) , DayOfWeek = DayOfWeek.Sunday, DoctorId =1 });
            WorkHour.Add(new WorkingHour() { Id = 2, FromWorkHour = new System.TimeSpan(8,0,0), ToWorkHour = new System.TimeSpan(17, 0, 0), DayOfWeek= DayOfWeek.Saturday, DoctorId=2 });
            WorkHour.Add(new WorkingHour() { Id = 3, FromWorkHour = new System.TimeSpan(8, 0, 0), ToWorkHour = new System.TimeSpan(20, 30, 0), DayOfWeek = DayOfWeek.Monday, DoctorId = 3 });

            builder.Entity<WorkingHour>().HasData(WorkHour);

        }
    }
}
