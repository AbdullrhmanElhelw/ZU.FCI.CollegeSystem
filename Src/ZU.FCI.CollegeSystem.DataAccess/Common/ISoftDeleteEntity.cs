namespace ZU.FCI.CollegeSystem.DataAccess.Common;

public interface ISoftDeleteEntity
{
    bool IsDeleted { get; }
    DateTime? DeletedOnUtc { get; }
}