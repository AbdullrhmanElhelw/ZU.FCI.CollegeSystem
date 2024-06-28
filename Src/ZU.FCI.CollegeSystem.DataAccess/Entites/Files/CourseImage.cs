using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Courses;

namespace ZU.FCI.CollegeSystem.DataAccess.Entites.Files;

public sealed class CourseImage : BaseFile
{
    #region Navigation Properties

    public int CourseId { get; set; }
    public Course Course { get; set; }

    #endregion Navigation Properties
}