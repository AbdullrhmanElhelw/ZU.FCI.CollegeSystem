using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Lectures;

namespace ZU.FCI.CollegeSystem.DataAccess.Data.Configurations;

internal sealed class LectureConfiguration : IEntityTypeConfiguration<Lecture>
{
    public void Configure(EntityTypeBuilder<Lecture> builder)
    {
        builder.ToTable("Lectures");

        builder.Property(e => e.Title)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(e => e.Description)
            .HasMaxLength(500);

        builder.HasMany(l => l.LectureFiles)
            .WithOne(lf => lf.Lecture)
            .HasForeignKey(lf => lf.LectureId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}