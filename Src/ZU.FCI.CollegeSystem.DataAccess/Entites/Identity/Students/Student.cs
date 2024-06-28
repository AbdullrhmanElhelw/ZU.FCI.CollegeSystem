using ZU.FCI.CollegeSystem.DataAccess.Common;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Departments;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Files;
using ZU.FCI.CollegeSystem.DataAccess.Enums;

namespace ZU.FCI.CollegeSystem.DataAccess.Entites.Identity.Students;

public class Student : ApplicationUser
{
    #region Properties

    public string SSN { get; set; }
    public Gender Gender { get; set; }

    #endregion Properties

    #region Navigation Properties

    public int? DepartmentId { get; set; }
    public Department? Department { get; set; }

    public int? ProfilePictureId { get; set; }
    public ProfilePicture? ProfilePicture { get; set; }

    #endregion Navigation Properties
}