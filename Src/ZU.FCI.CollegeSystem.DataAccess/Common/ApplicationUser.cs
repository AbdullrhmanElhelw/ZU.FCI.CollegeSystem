using Microsoft.AspNetCore.Identity;

namespace ZU.FCI.CollegeSystem.DataAccess.Common;

public class ApplicationUser : IdentityUser<int>, ISoftDeleteEntity, IAuditableEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";

    public DateTime CreatedOnUtc { get; set; }
    public DateTime? ModifiedOnUtc { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedOnUtc { get; set; }
}