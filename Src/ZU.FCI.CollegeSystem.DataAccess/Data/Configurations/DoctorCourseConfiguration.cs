using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.DoctorCourses;

namespace ZU.FCI.CollegeSystem.DataAccess.Data.Configurations;

internal sealed class DoctorCourseConfiguration : IEntityTypeConfiguration<DoctorCourse>
{
    public void Configure(EntityTypeBuilder<DoctorCourse> builder)
    {
        builder.ToTable("DoctorCourses");

        builder.HasKey(dc => new { dc.DoctorId, dc.CourseId });
    }
}