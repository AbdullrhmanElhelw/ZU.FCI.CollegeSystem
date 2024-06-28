using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.StudentCourses;

namespace ZU.FCI.CollegeSystem.DataAccess.Data.Configurations;

internal sealed class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
{
    public void Configure(EntityTypeBuilder<StudentCourse> builder)
    {
        builder.ToTable("StudentCourses");

        builder.HasKey(sc => new { sc.StudentId, sc.CourseId });
    }
}