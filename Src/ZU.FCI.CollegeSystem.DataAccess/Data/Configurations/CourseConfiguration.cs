using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Courses;

namespace ZU.FCI.CollegeSystem.DataAccess.Data.Configurations;

internal sealed class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("Courses");

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(e => e.Code)
            .IsRequired()
            .HasMaxLength(10);

        builder.HasMany(c => c.Lectures)
            .WithOne(l => l.Course)
            .HasForeignKey(l => l.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(c => c.Sections)
            .WithOne(s => s.Course)
            .HasForeignKey(s => s.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.CourseImage)
            .WithOne(ci => ci.Course)
            .HasForeignKey<Course>(c => c.CourseImageId);

        builder.HasMany(c => c.DoctorCourses)
            .WithOne(dc => dc.Course)
            .HasForeignKey(dc => dc.CourseId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}