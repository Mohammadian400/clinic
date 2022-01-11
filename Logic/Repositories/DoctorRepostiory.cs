using Data;
using Domain.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logic.Repositories
{
    public class DoctorRepostiory : Repository, IDoctorRepository
    {
        public DoctorRepostiory(ClinicContext context) : base(context)
        {
        }

        public List<DoctorViewModel> GetAll()
        {
            GetSomething();
            return
                DbContext.Doctors
                    .Select(doctor => new DoctorViewModel
                    {
                        Name = doctor.Name,
                        Family = doctor.Family,
                        Expertise = doctor.Expertise,
                        JobAddress = doctor.JobAddress,
                        Phone = doctor.Phone
                    }).ToList();
        }

        private void GetSomething()
        {
            var query = from f in DbContext.Doctors
                        let workingHours = (from c in DbContext.WorkingHours
                                            where f.Id == c.DoctorId
                                            orderby c.DoctorId, c.DayOfWeek
                                            select new 
                                            {
                                                c.DayOfWeek,
                                                c.FromWorkHour,
                                                c.ToWorkHour
                                            }).DefaultIfEmpty().AsEnumerable()

                        select new DoctorWithWorkingHour
                        {
                            Name = f.Name,
                            Family = f.Family,
                            Experience = f.Expertise,
                            WorkingHours = workingHours.Select(s => new WorkingHourDetailViewModel
                            {
                                DayOfWeek = s.DayOfWeek,
                                From = s.FromWorkHour,
                                To = s.ToWorkHour
                            })
                        };

            var queryString = query.ToQueryString();
            var result = query.ToList();

            //result.Select(s => s.WorkingHours.Select(q => q.DayOfWeek));
        }


        //public List<Domain.ViewModel.WorkingHourViewModel> DoctorFreeTime(long id)
        //{
        //    return DbContext.WorkingHours
        //           .Include(s => s.Doctor)
        //           .Where(s => s.DoctorId == id)
        //           .Select(s => new WorkingHourViewModel
        //           {

        //               DoctorName = s.Doctor.Name,
        //               DoctorFamily = s.Doctor.Family,
        //               DoctorExpertise = s.Doctor.Expertise,
        //               //Day = s.Day,
        //               FromWorkHour = s.FromWorkHour,
        //               ToWorkHour = s.ToWorkHour,


        //           }).ToList();
        //}
        public async Task EditDoctor(long id, DoctorViewModel model)
        {
            var doctor = await DbContext.Doctors.FindAsync(id);
            doctor.Name = model.Name;
            doctor.Family = model.Family;
            doctor.Expertise = model.Expertise;
            doctor.JobAddress = model.JobAddress;
            doctor.Phone = model.Phone;
            try
            {
                await DbContext.SaveChangesAsync();
            }
            catch //(DbUpdateConcurrencyException) when (!DoctorExists(id))
            {

            }
            //  ;

        }

    }

    public class DoctorWithWorkingHour
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string Experience { get; set; }

        public IEnumerable<WorkingHourDetailViewModel> WorkingHours { get; set; }
    }

    public class WorkingHourDetailViewModel
    {
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan From { get; set; }
        public TimeSpan To { get; set; }
    }
}