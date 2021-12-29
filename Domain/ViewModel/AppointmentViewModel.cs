using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ViewModel
{
    public class AppointmentViewModel
    {
        public long DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string DoctorFamily { get; set; }
        public string Expertise { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserFamily { get; set; }
        public int RemainingDays { get; set; }
    }
}
