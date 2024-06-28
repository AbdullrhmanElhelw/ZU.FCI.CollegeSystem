using ZU.FCI.CollegeSystem.DataAccess.Common;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Departments;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.DoctorCourses;

namespace ZU.FCI.CollegeSystem.DataAccess.Entites.Identity.Doctors;

public class Doctor : ApplicationUser
{
    #region Navigation Properties

    public int DepartmentId { get; set; }
    public Department Department { get; set; }

    public ICollection<DoctorCourse> DoctorCourses { get; set; } = [];

    #endregion Navigation Properties
}