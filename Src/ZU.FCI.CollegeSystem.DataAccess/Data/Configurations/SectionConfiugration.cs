using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Core;

namespace ZU.FCI.CollegeSystem.DataAccess.Data.Configurations;

internal class SectionConfiugration : IEntityTypeConfiguration<Section>
{
    public void Configure(EntityTypeBuilder<Section> builder)
    {
        builder.ToTable("Sections");

        builder.Property(e => e.Title)
            .IsRequired()
            .HasMaxLength(255);

        builder.HasMany(s => s.SectionFiles)
            .WithOne(sf => sf.Section)
            .HasForeignKey(sf => sf.SectionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}