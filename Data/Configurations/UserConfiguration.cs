using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Name).HasMaxLength(30).IsRequired();
            builder.Property(p => p.Image).HasMaxLength(250);
            builder.Property(p => p.NationalCode).HasMaxLength(10).IsRequired();
            builder.Property(p => p.Password).HasMaxLength(500).IsRequired();
            //builder.Property(p => p.RegisterDate).IsRequired();
            builder.Property(p => p.UserName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Family).HasMaxLength(50).IsRequired();

            // relations
            builder.HasMany(p => p.Appointments).WithOne(p => p.User).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(p => p.Logins).WithOne(p => p.User).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.NoAction);            
        }
    }
}
