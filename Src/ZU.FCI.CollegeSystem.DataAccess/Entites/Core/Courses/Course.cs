using ZU.FCI.CollegeSystem.DataAccess.Common;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Departments;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.DoctorCourses;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Lectures;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.StudentCourses;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Files;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Identity.Assistants;
using ZU.FCI.CollegeSystem.DataAccess.Enums;

namespace ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Courses;

public sealed class Course : BaseEntity
{
    #region Properties

    public string Name { get; set; }
    public Term Term { get; set; }
    public Level Level { get; set; }
    public Hours Hours { get; set; }
    public string Code { get; set; }

    #endregion Properties

    #region Navigation Properties

    public int DepartmentId { get; set; }
    public Department Department { get; set; }

    public int? CourseImageId { get; set; }
    public CourseImage? CourseImage { get; set; }

    public int? AssistantId { get; set; }
    public Assistant? Assistant { get; set; }

    public ICollection<Section> Sections { get; set; } = [];

    public ICollection<Lecture> Lectures { get; set; } = [];

    public ICollection<DoctorCourse> DoctorCourses { get; set; } = [];

    public ICollection<StudentCourse> StudentCourses { get; set; } = [];

    #endregion Navigation Properties
}