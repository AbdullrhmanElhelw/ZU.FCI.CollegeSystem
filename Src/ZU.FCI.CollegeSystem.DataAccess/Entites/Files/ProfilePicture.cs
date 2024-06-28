using ZU.FCI.CollegeSystem.DataAccess.Entites.Identity.Students;

namespace ZU.FCI.CollegeSystem.DataAccess.Entites.Files;

public sealed class ProfilePicture : BaseFile
{
    public int StudentId { get; set; }
    public Student Student { get; set; }
}