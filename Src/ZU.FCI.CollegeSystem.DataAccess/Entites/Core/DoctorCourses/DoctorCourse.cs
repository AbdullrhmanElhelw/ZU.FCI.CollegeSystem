using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Courses;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Identity.Doctors;

namespace ZU.FCI.CollegeSystem.DataAccess.Entites.Core.DoctorCourses;

public sealed class DoctorCourse
{
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }

    public int CourseId { get; set; }
    public Course Course { get; set; }
}