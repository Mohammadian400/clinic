using Data;
using Domain;
using Domain.ViewModel;
using Logic.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clinic.Repositories
{
    public class AppointmentRepository : Repository, IAppointmentRepository
    {
        public AppointmentRepository(ClinicContext context) : base(context)
        {
        }

        public List<AppointmentViewModel> GetAll()
        {
            return DbContext.Appointments
                    .Include(s => s.Doctor)
                    .Include(s => s.User)
                    .Select(s => new AppointmentViewModel
                    {
                        UserId = s.User.Id,
                        UserName = s.User.Name,
                        UserFamily = s.User.Family,
                        DoctorId = s.Doctor.Id,
                        DoctorName = s.Doctor.Name,
                        DoctorFamily = s.Doctor.Family,
                        Expertise = s.Doctor.Expertise,
                        AppointmentDate = s.AppointmentDate,
                        RemainingDays = s.RemainingDays()

                    }).ToList();

        }
        public async Task<long> CreateAppointment(StoreAppointment appointmentModel)                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 
        {
            // get all doctor appointements in special date
            var app =
                DbContext.Appointments
                    .Where(s => s.DoctorId == appointmentModel.DoctorId
                                && s.AppointmentDate.Day == appointmentModel.AppointmentDate.Day
                                && s.AppointmentDate.Month == appointmentModel.AppointmentDate.Month
                                && s.AppointmentDate.Year == appointmentModel.AppointmentDate.Year)
                    .OrderBy(item => item.AppointmentDate)
                    .Last(); //.Select(s => s.AppointmentDate)    //.ToList();
            //TimeSpan appointlast = app.AppointmentDate.TimeOfDay;
            DateTime appointlast = app.AppointmentDate;

            //&&s.AppointmentDate.Hour == appointmentModel.AppointmentDate.Hour && s.AppointmentDate.Minute == appointmentModel.AppointmentDate.Minute

            //var ll = new TimeSpan(0, 0, 0);
            // ll.add
            int interval = DbContext.Doctors.Where(u => u.Id == appointmentModel.DoctorId).Select(u => u.AppointmentInterval).SingleOrDefault();
            TimeSpan oldfromworkhour= DbContext.WorkingHours.Where(u => u.DoctorId == appointmentModel.DoctorId 
            && u.DayOfWeek== appointmentModel.AppointmentDate.DayOfWeek).Select(u => u.ToWorkHour).SingleOrDefault();
            DateTime newappoint = appointlast.Add(new TimeSpan(0, interval, 0));
            //AddMinutes(interval);
            TimeSpan newappoint1 = newappoint.TimeOfDay;
            if (newappoint1 > oldfromworkhour)
            {
                throw new Exception("This time is taken by another user");
            }

            // move on each appointment for find conflict time
            //foreach (var item in app)
            //{
            //    var appoint = item;
            //    // check appointemtn start time with appointmentModel
            //    var useradd = item.AddMinutes(interval);
            //    var modeladd = appointmentModel.AppointmentDate.AddMinutes(interval);

            //    if ((appointmentModel.AppointmentDate >= appoint && appointmentModel.AppointmentDate <= useradd) || (modeladd >= appoint && modeladd <= useradd))
            //    {
            //        // throw exception if found confilct
            //        throw new Exception("This time is taken by another user");
            //    }
            //}

            // create new object from entity by model
            var appointment = new Appointment
            {
                UserId = appointmentModel.UserId,
                DoctorId = appointmentModel.DoctorId,
                AppointmentDate = newappoint,
            };

            // add new object to ef context (table)
            DbContext.Appointments.Add(appointment);

            // save changes
            await DbContext.SaveChangesAsync();
            return appointment.Id;
           
        }

        private void GetAppointment(StoreAppointment appointmentModel) {
            // get doctor interval time (by minutes)

            // get doctor WorkingHour in user selected time

            // calc appointment end time

            // validate appointment time

            // save appointment
        }
        public async Task DeleteAppointment(long id)
        {
            var appointment = await DbContext.Appointments.FindAsync(id);

            // todo : implement try catch
            //if (appointment == null)
            //{
            //    return NotFound();
            //}
            DbContext.Appointments.Remove(appointment);
            await DbContext.SaveChangesAsync();
        }

       
    }
}
