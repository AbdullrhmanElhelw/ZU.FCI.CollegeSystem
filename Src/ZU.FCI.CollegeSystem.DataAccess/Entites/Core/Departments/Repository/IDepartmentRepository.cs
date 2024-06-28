namespace ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Departments.Repository;

public interface IDepartmentRepository
{
    Task<bool> CheckIsExists(int id);

    Task<Department?> GetDepartmentById(int id);
}