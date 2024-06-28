namespace ZU.FCI.CollegeSystem.DataAccess.Common;

public interface IAuditableEntity
{
    DateTime CreatedOnUtc { get; }

    DateTime? ModifiedOnUtc { get; }
}
