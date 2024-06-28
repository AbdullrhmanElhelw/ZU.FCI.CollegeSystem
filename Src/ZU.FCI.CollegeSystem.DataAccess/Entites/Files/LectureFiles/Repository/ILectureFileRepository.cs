namespace ZU.FCI.CollegeSystem.DataAccess.Entites.Files.LectureFiles.Repository;

public interface ILectureFileRepository
{
    Task<LectureFile> GetLectureFileByIdAsync(int lectureFileId, CancellationToken cancellationToken);

    void Insert(LectureFile lectureFile);
}