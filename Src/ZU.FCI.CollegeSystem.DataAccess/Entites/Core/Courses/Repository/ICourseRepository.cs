namespace ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Courses.Repository;

public interface ICourseRepository
{
    Task<bool> CheckIsExits(string name);

    Task<bool> CheckIsExits(int id);

    Task<Course?> GetCourse(int id, CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<Course>> GetCourses(CancellationToken cancellationToken = default);

    void Insert(Course course);
}