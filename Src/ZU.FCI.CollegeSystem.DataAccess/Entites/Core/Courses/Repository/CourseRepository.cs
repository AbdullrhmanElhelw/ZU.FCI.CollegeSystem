using Microsoft.EntityFrameworkCore;
using ZU.FCI.CollegeSystem.DataAccess.Data;
using ZU.FCI.CollegeSystem.DataAccess.Enums;

namespace ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Courses.Repository;

public class CourseRepository : ICourseRepository
{
    private readonly CollegeSystemDbContext _context;

    public CourseRepository(CollegeSystemDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CheckIsExits(string name)
    {
        var isExists = await _context.Courses.AnyAsync(x => x.Name == name);
        return isExists;
    }

    public async Task<bool> CheckIsExits(int id)
    {
        var isExists = await _context.Courses.AnyAsync(x => x.Id == id);
        return isExists;
    }

    public async Task<IReadOnlyCollection<Course>> FindCourseByLevelAndTerm(Level level, Term term,
        CancellationToken cancellationToken = default) =>
        await _context.Courses
        .Include(x => x.Department)
        .Where(x => x.Level == level && x.Term == term)
        .Select(x => new Course
        {
            Id = x.Id,
            Name = x.Name,
            Level = x.Level,
            Hours = x.Hours,
            Code = x.Code,
            Department = new Departments.Department
            {
                Id = x.Department.Id,
                Name = x.Department.Name
            }
        }).ToListAsync(cancellationToken: cancellationToken);

    public Task<Course?> GetCourse(int id, CancellationToken cancellationToken = default) =>
    _context.Courses
        .Include(x => x.Department)
        .Where(x => x.Id == id)
        .Select(x => new Course
        {
            Id = x.Id,
            Name = x.Name,
            Level = x.Level,
            Hours = x.Hours,
            Code = x.Code,
            Department = x.Department
        })
        .FirstOrDefaultAsync(cancellationToken);

    public async Task<IReadOnlyCollection<Course>> GetCourses(CancellationToken cancellationToken = default)
        =>
       await _context.Courses
            .Include(x => x.Department)
            .Select(x => new Course
            {
                Id = x.Id,
                Name = x.Name,
                Level = x.Level,
                Hours = x.Hours,
                Code = x.Code,
                Department = x.Department
            })
            .ToListAsync(cancellationToken);

    public void Insert(Course course) =>
        _context.Courses.Add(course);
}