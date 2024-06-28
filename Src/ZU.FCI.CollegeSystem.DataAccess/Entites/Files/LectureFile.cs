using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Lectures;

namespace ZU.FCI.CollegeSystem.DataAccess.Entites.Files;

public sealed class LectureFile : BaseFile
{
    #region Properties

    public string Title { get; set; }

    #endregion Properties

    #region Navigation Properties

    public int LectureId { get; set; }
    public Lecture Lecture { get; set; }

    #endregion Navigation Properties
}