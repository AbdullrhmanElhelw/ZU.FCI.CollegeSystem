using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Identity.Doctors;

namespace ZU.FCI.CollegeSystem.DataAccess.Data.Configurations;

internal sealed class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.ToTable("Doctors");

        builder.HasMany(d => d.DoctorCourses)
            .WithOne(dc => dc.Doctor)
            .HasForeignKey(dc => dc.DoctorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}