namespace ZU.FCI.CollegeSystem.DataAccess.Contracts;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}