namespace ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Lectures.Repository;

public interface ILectureRepository
{
    Task<bool> CheckIsExistsAsync(string title);

    Task<Lecture?> GetLectureByIdAsync(int lectureId, CancellationToken cancellationToken);

    void InsertLecture(Lecture lecture);
}