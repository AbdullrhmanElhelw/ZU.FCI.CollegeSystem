using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZU.FCI.CollegeSystem.DataAccess.Data.Migrations;

/// <inheritdoc />
public partial class SeedingDepartments : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("SET IDENTITY_INSERT Departments ON");

        migrationBuilder.Sql(@"
            INSERT INTO Departments (id, name, code, CreatedOnUtc, IsDeleted) VALUES
            (1, 'Computer Science', 'CS', '2024-06-28', 0)");

        migrationBuilder.Sql(@"
            INSERT INTO Departments (id, name, code, CreatedOnUtc, IsDeleted) VALUES
            (2, 'Information Technology', 'IT', '2024-06-28', 0)");

        migrationBuilder.Sql(@"
            INSERT INTO Departments (id, name, code, CreatedOnUtc, IsDeleted) VALUES
            (3, 'Information Systems', 'IS', '2024-06-28', 0)");

        migrationBuilder.Sql(@"
            INSERT INTO Departments (id, name, code, CreatedOnUtc, IsDeleted) VALUES
            (4, 'Data Science', 'DS', '2024-06-28', 0)");

        migrationBuilder.Sql(@"
            INSERT INTO Departments (id, name, code, CreatedOnUtc, IsDeleted) VALUES
            (5, 'Artificial Intelligence', 'AI', '2024-06-28', 0)");

        migrationBuilder.Sql(@"
            INSERT INTO Departments (id, name, code, CreatedOnUtc, IsDeleted) VALUES
            (6, 'Machine Intelligence', 'MI', '2024-06-28', 0)");

        migrationBuilder.Sql("SET IDENTITY_INSERT Departments OFF");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("DELETE FROM Departments WHERE id IN (1, 2, 3, 4, 5, 6)");
    }
}