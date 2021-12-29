using Data;
using Domain;
using Domain.ViewModel;
using Logic.Repositories;
using Microsoft.EntityFrameworkCore;
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
            // create new object from entity by model
            var appointment = new Appointment
            {
                UserId = appointmentModel.UserId,
                DoctorId = appointmentModel.DoctorId,
                AppointmentDate = appointmentModel.AppointmentDate,
            };

            // add new object to ef context (table)
            DbContext.Appointments.Add(appointment);

            // save changes
            await DbContext.SaveChangesAsync();

            return appointment.Id;
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
