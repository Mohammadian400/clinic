using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModel
{
    public class WorkingHourViewModel
    {
        public TimeSpan FromWorkHour { get; set; }
        public TimeSpan ToWorkHour { get; set; }
        //public DaysOfWeek Day { get; set; }
        public long DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string DoctorFamily { get; set; }
        public string DoctorExpertise { get; set; }
    }
}
