using FluentResults;
using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.CQRS.Queries;
using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.Errors;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Lectures.Repository;

namespace ZU.FCI.CollegeSystem.BusinessLogic.Lectures.Queries.GetLecture;

public sealed record GetLectureQuery
    (int LectureId) : IQuery<GetLectureDto>;

public sealed record GetLectureDto
    (int Id, string Title);

public sealed class GetLectureQueryHandler : IQueryHandler<GetLectureQuery, GetLectureDto>
{
    private readonly ILectureRepository _lectureRepository;

    public GetLectureQueryHandler(ILectureRepository lectureRepository)
    {
        _lectureRepository = lectureRepository;
    }

    public async Task<Result<GetLectureDto>> Handle(GetLectureQuery request, CancellationToken cancellationToken)
    {
        var lecture = await _lectureRepository.GetLectureByIdAsync(request.LectureId, cancellationToken);

        if (lecture is null)
            return new Result<GetLectureDto>().WithError(new RecordNotFoundError($"Lecture with #{request.LectureId} not found"));

        return Result.Ok(new GetLectureDto(lecture.Id, lecture.Title));
    }
}