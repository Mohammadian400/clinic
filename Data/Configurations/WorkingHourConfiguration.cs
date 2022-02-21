using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
   public class WorkingHourConfiguration: IEntityTypeConfiguration<WorkingHour>
    {
        public void Configure(EntityTypeBuilder<WorkingHour> builder)
        {
            builder.HasKey(p => p.Id); 
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.FromWorkHour).IsRequired();
            builder.Property(p => p.ToWorkHour).IsRequired();
            builder.Property(p => p.DayOfWeek).IsRequired();

            builder.HasOne(p => p.Doctor).WithMany(p => p.WorkingHours).HasForeignKey(p => p.DoctorId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
