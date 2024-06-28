using Microsoft.EntityFrameworkCore;
using ZU.FCI.CollegeSystem.DataAccess.Data;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Identity.Doctors;

namespace ZU.FCI.CollegeSystem.DataAccess.Entites.Files.LectureFiles.Repository;

public class LectureFileRepository : ILectureFileRepository
{
    private readonly CollegeSystemDbContext _context;

    public LectureFileRepository(CollegeSystemDbContext context)
    {
        _context = context;
    }

    public async Task<LectureFile?> GetLectureFileByIdAsync(int lectureFileId, CancellationToken cancellationToken) =>
       await _context.LectureFiles
        .Include(lf => lf.Doctor)
        .Where(lf => lf.Id == lectureFileId)
        .Select(lf => new LectureFile
        {
            Id = lf.Id,
            Name = lf.Name,
            Doctor = new Doctor
            {
                Id = lf.Doctor.Id,
                FirstName = lf.Doctor.FirstName,
                LastName = lf.Doctor.LastName
            }
        }).FirstOrDefaultAsync(cancellationToken);

    public void Insert(LectureFile lectureFile) =>
        _context.LectureFiles.Add(lectureFile);
}