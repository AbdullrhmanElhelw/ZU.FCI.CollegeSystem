using ZU.FCI.CollegeSystem.DataAccess.Common;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Courses;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Departments;

namespace ZU.FCI.CollegeSystem.DataAccess.Entites.Identity.Assistants;

public class Assistant : ApplicationUser
{
    #region Navigation Properties

    public int DepartmentId { get; set; }
    public Department Department { get; set; }

    public ICollection<Course> Courses { get; set; }

    #endregion Navigation Properties
}