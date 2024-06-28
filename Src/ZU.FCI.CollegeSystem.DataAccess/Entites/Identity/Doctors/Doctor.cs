using ZU.FCI.CollegeSystem.DataAccess.Common;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Departments;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.DoctorCourses;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Files.LectureFiles;

namespace ZU.FCI.CollegeSystem.DataAccess.Entites.Identity.Doctors;

public class Doctor : ApplicationUser
{
    #region Navigation Properties

    public int DepartmentId { get; set; }
    public Department Department { get; set; }

    public ICollection<DoctorCourse> DoctorCourses { get; set; } = [];

    public ICollection<LectureFile> LectureFiles { get; set; } = [];

    #endregion Navigation Properties
}