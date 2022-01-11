using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class WorkingHour
    {
        public long Id { get; set; }
        public TimeSpan FromWorkHour { get; set; }
        public TimeSpan ToWorkHour { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public long DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
    }

    //public enum DaysOfWeek
    //{
    //    Saturday = 1,
    //    Sunday = 2,
    //    Monday = 3,
    //    Tuesday = 4,
    //    Wednesday = 5,
    //    Thursday = 6,
    //    Friday = 7
    //}
}
