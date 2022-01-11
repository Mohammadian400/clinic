using Domain.ViewModel;
using Logic.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace clinic.Controllers
{
    public class AppointmentController : BaseApiController
    {
        private readonly IAppointmentRepository  _repository;
        public AppointmentController(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<List<AppointmentViewModel>> GetAppointments()
        {
            //var query = DbContext.Appointments
            //    .Include(s => s.Doctor)
            //    .Include(s => s.User)
            //    .Select(s => new AppointmentViewModel
            //    {
            //        UserName = s.User.Name,
            //        UserFamily = s.User.Family,
            //        DoctorName = s.Doctor.Name,
            //        DoctorFamily = s.Doctor.Family,
            //        Expertise = s.Doctor.Expertise,
            //        AppointmentDate = s.AppointmentDate

            //    });

            //query = query.Where(w => w.Expertise == "");
            //query = query.GroupBy(g => g.DoctorFamily, new { })


            var appointments = _repository.GetAll();
            //DbContext.Appointments
            //        .Include(s => s.Doctor)
            //        .Include(s => s.User)
            //        .Select(s => new AppointmentViewModel
            //        {
            //            UserId = s.User.Id,
            //            UserName = s.User.Name,
            //            UserFamily = s.User.Family,
            //            DoctorId = s.Doctor.Id,
            //            DoctorName = s.Doctor.Name,
            //            DoctorFamily = s.Doctor.Family,
            //            Expertise = s.Doctor.Expertise,
            //            AppointmentDate = s.AppointmentDate,
            //            RemainingDays = s.RemainingDays()

            //        }).ToList();

            return Ok(appointments);
        }

        [HttpPost]
        public async Task<ActionResult<long>> CreateAppointment(StoreAppointment model)
        {
            return Ok(await _repository.CreateAppointment(model));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(long id)
        {
            await _repository.DeleteAppointment(id);
            return NoContent();
        }
    }
}
