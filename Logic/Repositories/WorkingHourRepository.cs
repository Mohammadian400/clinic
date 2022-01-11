using Data;
using Logic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class WorkingHourRepository : Repository, IWorkingHourRepository
    {
        public WorkingHourRepository(ClinicContext context) : base(context)
        {
        }
        //public async Task FreeTime(long id, DateTime AppointmentDate)
        //{

        //    var freetime = await DbContext.Appointments.Where(s => s.DoctorId == id && s.AppointmentDate == AppointmentDate).OrderByDescending(item => item.AppointmentDate).First();
        //    var ll = DbContext.Doctors.AppointmentInterval;
        //    var NewWorkHour=DbContext.WorkingHours.
        //    try
        //    {
        //        await DbContext.SaveChangesAsync();
        //    }
        //    catch //(DbUpdateConcurrencyException) when (!DoctorExists(id))
        //    {

        //    }
        //}
    }
}