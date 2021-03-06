using Domain.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.Repositories
{
    public interface IDoctorRepository
    {
        List<DoctorViewModel> GetAll();
        Task EditDoctor(long id,DoctorViewModel model);
    }
}
