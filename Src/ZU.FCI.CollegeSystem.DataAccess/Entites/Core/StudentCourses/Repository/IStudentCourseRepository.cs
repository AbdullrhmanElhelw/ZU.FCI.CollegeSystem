namespace ZU.FCI.CollegeSystem.DataAccess.Entites.Core.StudentCourses.Repository;

public interface IStudentCourseRepository
{
    Task<bool> CheckIsRegistred(int courseId, int StudentId);

    void RegisterCourse(int courseId, int studentId);
}