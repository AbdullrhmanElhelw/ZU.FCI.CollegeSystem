using ZU.FCI.CollegeSystem.DataAccess.Common;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Courses;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Identity.Assistants;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Identity.Doctors;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Identity.Students;

namespace ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Departments;

public sealed class Department : BaseEntity
{
    #region Properties

    public string Name { get; set; }
    public string Code { get; set; }

    #endregion Properties

    #region Navigation Properties

    public ICollection<Assistant> Assistants { get; set; } = [];
    public ICollection<Doctor> Doctors { get; set; } = [];
    public ICollection<Student> Students { get; set; } = [];
    public ICollection<Course> Courses { get; set; } = [];

    #endregion Navigation Properties
}