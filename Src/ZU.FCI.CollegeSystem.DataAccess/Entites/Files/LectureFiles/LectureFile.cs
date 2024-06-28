using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Lectures;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Identity.Doctors;

namespace ZU.FCI.CollegeSystem.DataAccess.Entites.Files.LectureFiles;

public sealed class LectureFile : BaseFile
{
    #region Properties

    public string Title { get; set; }

    #endregion Properties

    #region Navigation Properties

    public int? DoctorId { get; set; }
    public Doctor? Doctor { get; set; }

    public int LectureId { get; set; }
    public Lecture Lecture { get; set; }

    #endregion Navigation Properties
}