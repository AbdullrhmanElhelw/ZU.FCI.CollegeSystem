using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZU.FCI.CollegeSystem.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[AspNetRoles] ON");

            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (1, N'Admin', N'ADMIN', '" + Guid.NewGuid().ToString() + "')");
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (2, N'Student', N'STUDENT', '" + Guid.NewGuid().ToString() + "')");
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (3, N'Doctor', N'DOCTOR', '" + Guid.NewGuid().ToString() + "')");
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (4, N'Assistant', N'ASSISTANT', '" + Guid.NewGuid().ToString() + "')");
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (5, N'Parent', N'PARENT', '" + Guid.NewGuid().ToString() + "')");

            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[AspNetRoles] OFF");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [dbo].[AspNetRoles] WHERE [Id] IN (1, 2, 3, 4, 5)");
        }
    }
}