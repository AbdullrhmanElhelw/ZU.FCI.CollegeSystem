using Microsoft.EntityFrameworkCore;
using ZU.FCI.CollegeSystem.DataAccess.Data;

namespace ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Departments.Repository;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly CollegeSystemDbContext _context;

    public DepartmentRepository(CollegeSystemDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CheckIsExists(int id) =>
        await _context.Departments.FindAsync(id) is not null;

    public async Task<Department?> GetDepartmentById(int id) =>
       await _context.Departments.FirstOrDefaultAsync(x => x.Id == id);
}