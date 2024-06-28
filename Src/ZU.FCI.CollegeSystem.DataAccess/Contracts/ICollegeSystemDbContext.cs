using Microsoft.EntityFrameworkCore;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Core;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Courses;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Departments;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Lectures;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Files;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Identity.Students;

namespace ZU.FCI.CollegeSystem.DataAccess.Contracts;

public interface ICollegeSystemDbContext
{
    DbSet<Student> Students { get; }
    DbSet<Course> Courses { get; }
    DbSet<Department> Departments { get; }
    DbSet<Lecture> Lectures { get; }
    DbSet<Section> Sections { get; }
    DbSet<CourseImage> CourseImages { get; }
    DbSet<LectureFile> LectureFiles { get; }
    DbSet<SectionFile> SectionFiles { get; }
    DbSet<ProfilePicture> ProfilePictures { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}