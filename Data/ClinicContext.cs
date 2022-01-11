using Data.Configurations;
using Data.Seeds;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ClinicContext : DbContext
    {
        public ClinicContext(DbContextOptions<ClinicContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<WorkingHour> WorkingHours { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // seed
            modelBuilder.InsertDoctor();
            modelBuilder.InsertUser();
            modelBuilder.InsertWorkingHour();
            // add configuration
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorConfiguration());
            modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
            modelBuilder.ApplyConfiguration(new LoginConfiguration());
            modelBuilder.ApplyConfiguration(new WorkingHourConfiguration());


        }
    }
}