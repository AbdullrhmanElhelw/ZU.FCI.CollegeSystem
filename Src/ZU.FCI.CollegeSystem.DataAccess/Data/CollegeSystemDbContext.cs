using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZU.FCI.CollegeSystem.DataAccess.Common;
using ZU.FCI.CollegeSystem.DataAccess.Contracts;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Core;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Courses;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Departments;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Lectures;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Files;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Files.LectureFiles;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Identity.Students;

namespace ZU.FCI.CollegeSystem.DataAccess.Data;

public class CollegeSystemDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>,
    ICollegeSystemDbContext, IUnitOfWork
{
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Course> Courses => Set<Course>();

    public DbSet<Lecture> Lectures => Set<Lecture>();

    public DbSet<Section> Sections => Set<Section>();

    public DbSet<LectureFile> LectureFiles => Set<LectureFile>();
    public DbSet<SectionFile> SectionFiles => Set<SectionFile>();

    public DbSet<CourseImage> CourseImages => Set<CourseImage>();

    public DbSet<ProfilePicture> ProfilePictures => Set<ProfilePicture>();

    public CollegeSystemDbContext(DbContextOptions<CollegeSystemDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(CollegeSystemDbContext).Assembly);
        base.OnModelCreating(builder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}