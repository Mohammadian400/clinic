using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ViewModel
{
    public class StoreAppointment
    {
        //public int year;

        public long DoctorId { get; set; }
        public int UserId { get; set; }
        public DateTime AppointmentDate { get; set; }
       
        //public int Month { get; set; }
    }
}
