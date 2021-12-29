using Domain.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.Repositories
{
    public interface IAppointmentRepository
    {
        List<AppointmentViewModel> GetAll();
        Task<long> CreateAppointment(StoreAppointment appointmentModel);
        Task DeleteAppointment(long id);
    }
}
