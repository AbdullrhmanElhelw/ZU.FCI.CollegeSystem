using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Files;

namespace ZU.FCI.CollegeSystem.DataAccess.Data.Configurations;

internal sealed class BaseFileConfiguration : IEntityTypeConfiguration<BaseFile>
{
    public void Configure(EntityTypeBuilder<BaseFile> builder)
    {
        builder.ToTable("Files");

        builder.UseTptMappingStrategy();

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(e => e.Extension)
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(e => e.Content)
            .IsRequired();
    }
}