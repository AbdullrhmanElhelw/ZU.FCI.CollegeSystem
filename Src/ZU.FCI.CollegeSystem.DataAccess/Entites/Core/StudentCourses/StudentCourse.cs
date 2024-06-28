using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Courses;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Identity.Students;

namespace ZU.FCI.CollegeSystem.DataAccess.Entites.Core.StudentCourses;

public sealed class StudentCourse
{
    #region Properties

    public int StudentId { get; set; }
    public Student Student { get; set; }

    public int CourseId { get; set; }
    public Course Course { get; set; }

    public bool IsVerified { get; set; }

    #endregion Properties
}