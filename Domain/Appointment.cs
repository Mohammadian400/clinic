using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Appointment
    {
        public long Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int UserId { get; set; }
        public long DoctorId { get; set; }

        //[ForeignKey("DoctorId")]
        public virtual User User { get; set; }
        public virtual Doctor Doctor { get; set; }

        public int RemainingDays()
        {
            var now = DateTime.Now;
            var remainig = now - AppointmentDate;

            return remainig.Days;
        }
        //public int RemainingDays { get
               // }

    }
}
