using FluentResults;
using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.CQRS.Queries;
using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.Errors;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Lectures.Repository;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Files.LectureFiles.Repository;

namespace ZU.FCI.CollegeSystem.BusinessLogic.Lectures.Queries.GetLectureFileInformation;

public sealed record GetLectureFileInformationQuery
    (int LectureId, int FileId) : IQuery<GetFileInfDto>;

public sealed class GetLectureFileInformationQueryHandler
    : IQueryHandler<GetLectureFileInformationQuery, GetFileInfDto>
{
    private readonly ILectureFileRepository _lectureFileRepository;
    private readonly ILectureRepository _lectureRepository;

    public GetLectureFileInformationQueryHandler(ILectureFileRepository lectureFileRepository,
                                                 ILectureRepository lectureRepository)
    {
        _lectureFileRepository = lectureFileRepository;
        _lectureRepository = lectureRepository;
    }

    public async Task<Result<GetFileInfDto>> Handle(GetLectureFileInformationQuery request, CancellationToken cancellationToken)
    {
        var checkLectureIsExists = await _lectureRepository.GetLectureByIdAsync(request.LectureId, cancellationToken);

        if (checkLectureIsExists is null)
            return new Result<GetFileInfDto>().WithError(new RecordNotFoundError($"Lecture with #{request.LectureId} Not Found"));

        var lectureFile = await _lectureFileRepository.GetLectureFileByIdAsync(request.FileId, cancellationToken);

        if (lectureFile is null)
            return new Result<GetFileInfDto>().WithError(new RecordNotFoundError($"Lecture File with #{request.FileId} Not Found"));

        return Result.Ok(new GetFileInfDto(lectureFile.Id, lectureFile.Name, lectureFile.Doctor.FullName));
    }
}

public sealed record GetFileInfDto
    (int FileId,
    string FileName,
    string UploadedBy);