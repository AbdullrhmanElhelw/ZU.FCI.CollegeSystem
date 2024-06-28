using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Identity.Assistants;

namespace ZU.FCI.CollegeSystem.DataAccess.Data.Configurations;

internal sealed class AssistantConfiguration : IEntityTypeConfiguration<Assistant>
{
    public void Configure(EntityTypeBuilder<Assistant> builder)
    {
        builder.ToTable("Assistants");

        builder.HasMany(a => a.Courses)
            .WithOne(c => c.Assistant)
            .HasForeignKey(a => a.AssistantId);
    }
}