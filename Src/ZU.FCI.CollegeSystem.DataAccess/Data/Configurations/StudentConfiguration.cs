using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Identity.Students;

namespace ZU.FCI.CollegeSystem.DataAccess.Data.Configurations;

internal sealed class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students");

        builder.Property(s => s.SSN)
            .HasMaxLength(14)
            .IsRequired();

        builder.Property(e => e.Gender)
            .IsRequired();

        builder.HasOne(s => s.ProfilePicture)
            .WithOne(p => p.Student)
            .HasForeignKey<Student>(s => s.ProfilePictureId);
    }
}