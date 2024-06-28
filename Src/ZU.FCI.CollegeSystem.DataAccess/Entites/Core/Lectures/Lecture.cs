using ZU.FCI.CollegeSystem.DataAccess.Common;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Courses;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Files;

namespace ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Lectures;

public sealed class Lecture : BaseEntity
{
    #region Properties

    public string Title { get; set; }

    #endregion Properties

    #region Navigation Properties

    public int CourseId { get; set; }
    public Course Course { get; set; }

    public ICollection<LectureFile> LectureFiles { get; set; } = [];

    #endregion Navigation Properties
}