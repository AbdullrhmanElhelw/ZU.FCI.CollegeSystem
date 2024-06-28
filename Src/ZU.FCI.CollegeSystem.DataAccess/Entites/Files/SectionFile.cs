using ZU.FCI.CollegeSystem.DataAccess.Entites.Core;

namespace ZU.FCI.CollegeSystem.DataAccess.Entites.Files;

public sealed class SectionFile : BaseFile
{
    #region Properties

    public string Title { get; set; }

    #endregion Properties

    #region Navigation Properties

    public int SectionId { get; set; }
    public Section Section { get; set; }

    #endregion Navigation Properties
}