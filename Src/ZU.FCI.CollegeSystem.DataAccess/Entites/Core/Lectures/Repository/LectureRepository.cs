using Microsoft.EntityFrameworkCore;
using ZU.FCI.CollegeSystem.DataAccess.Data;

namespace ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Lectures.Repository;

public class LectureRepository : ILectureRepository
{
    private readonly CollegeSystemDbContext _context;

    public LectureRepository(CollegeSystemDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CheckIsExistsAsync(string title) =>
        await _context.Lectures.AnyAsync(x => x.Title == title);

    public async Task<Lecture?> GetLectureByIdAsync(int lectureId, CancellationToken cancellationToken) =>
        await _context.Lectures
        .Where(x => x.Id == lectureId)
        .Select(x => new Lecture
        {
            Id = x.Id,
            Title = x.Title
        }).FirstOrDefaultAsync(cancellationToken);

    public void InsertLecture(Lecture lecture) =>
        _context.Lectures.Add(lecture);
}