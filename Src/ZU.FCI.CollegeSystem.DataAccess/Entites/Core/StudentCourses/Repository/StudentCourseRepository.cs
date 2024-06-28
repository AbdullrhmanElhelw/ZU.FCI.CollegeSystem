using Microsoft.EntityFrameworkCore;
using ZU.FCI.CollegeSystem.DataAccess.Data;

namespace ZU.FCI.CollegeSystem.DataAccess.Entites.Core.StudentCourses.Repository;

public class StudentCourseRepository : IStudentCourseRepository
{
    private readonly CollegeSystemDbContext _context;

    public StudentCourseRepository(CollegeSystemDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CheckIsRegistred(int courseId, int StudentId) =>
         await _context.StudentCourses
        .Where(x => x.CourseId == courseId && x.StudentId == StudentId)
        .AnyAsync();

    public void RegisterCourse(int courseId, int studentId)
        => _context.StudentCourses.Add(new StudentCourse
        {
            CourseId = courseId,
            StudentId = studentId,
            IsVerified = false
        });
}