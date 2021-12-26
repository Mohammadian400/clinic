using Data;
using Domain.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Repositories
{
    public class DoctorRepostiory : Repository, IDoctorRepository
    {
        public DoctorRepostiory(ClinicContext context):base(context)
        {
        }

        public List<DoctorViewModel> GetAll()
        {
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
    }
}
