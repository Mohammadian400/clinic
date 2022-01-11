using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Doctor
    {   
        public long Id { get; set; }
        public string Name { get; set; } 
        public string Family { get; set; }        
        public string Expertise { get; set; }
        public string JobAddress { get; set; }
        public string Phone { get; set; }
        public int  AppointmentInterval { get;set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<WorkingHour> WorkingHours { get; set; }
    }
    
}
