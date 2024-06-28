using ZU.FCI.CollegeSystem.DataAccess.Common;

namespace ZU.FCI.CollegeSystem.DataAccess.Entites.Files;

public class BaseFile : BaseEntity
{
    public string Name { get; set; }
    public byte[] Content { get; set; }
    public string Extension { get; set; }
}