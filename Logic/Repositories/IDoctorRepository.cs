using Domain.ViewModel;
using System.Collections.Generic;

namespace Logic.Repositories
{
    public interface IDoctorRepository
    {
        List<DoctorViewModel> GetAll();
    }
}
