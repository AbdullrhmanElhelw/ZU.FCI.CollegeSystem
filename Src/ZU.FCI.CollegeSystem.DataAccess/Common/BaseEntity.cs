namespace ZU.FCI.CollegeSystem.DataAccess.Common;

public abstract class BaseEntity : IAuditableEntity, ISoftDeleteEntity
{
    public int Id { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public DateTime? ModifiedOnUtc { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedOnUtc { get; set; }
}
