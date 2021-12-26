using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class DoctorConfiguration: IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Name).HasMaxLength(30).IsRequired();
            builder.Property(p => p.Family).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Expertise).HasMaxLength(50).IsRequired();
            builder.Property(p => p.JobAddress).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Phone).HasMaxLength(12).IsRequired();
            
            // relations
            builder.HasMany(p => p.Appointments).WithOne(p => p.Doctor).HasForeignKey(p => p.DoctorId).OnDelete(DeleteBehavior.NoAction);
        
        }
        
    }
}
