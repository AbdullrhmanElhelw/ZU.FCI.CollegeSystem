using FluentResults;
using FluentValidation;
using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.CQRS.Commands;
using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.Errors;
using ZU.FCI.CollegeSystem.DataAccess.Contracts;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Courses.Repository;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Lectures;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Lectures.Repository;

namespace ZU.FCI.CollegeSystem.BusinessLogic.Lectures.Commands.InsertLecture;

public sealed record InsertLectureCommand
    (string Title, int CourseId) : ICommand;

public sealed class InsertLectureCommandHandler : ICommandHandler<InsertLectureCommand>
{
    private readonly ILectureRepository _lectureRepository;
    private readonly ICourseRepository _courseRepository;
    private readonly IUnitOfWork _unitOfwork;

    public InsertLectureCommandHandler(ILectureRepository lectureRepository, ICourseRepository courseRepository, IUnitOfWork unitOfwork)
    {
        _lectureRepository = lectureRepository;
        _courseRepository = courseRepository;
        _unitOfwork = unitOfwork;
    }

    public async Task<Result> Handle(InsertLectureCommand request, CancellationToken cancellationToken)
    {
        var checkLectureExists = await _lectureRepository.CheckIsExistsAsync(request.Title);
        if (checkLectureExists is true)
            return new Result().WithError(new RecordIsAlreadyExists($"Lecture with {request.Title} is already Exists"));

        var checkCourseExists = await _courseRepository.CheckIsExits(request.CourseId);

        if (checkCourseExists is false)
            return new Result().WithError(new RecordNotFoundError($"Course with {request.CourseId} is not found"));

        var lecture = new Lecture
        {
            Title = request.Title,
            CourseId = request.CourseId
        };

        _lectureRepository.InsertLecture(lecture);

        return await _unitOfwork.SaveChangesAsync() == 0 ?
            Result.Fail("Failed to insert lecture") :
            Result.Ok();
    }
}

public sealed class InsertLectureValidator : AbstractValidator<InsertLectureCommand>
{
    public InsertLectureValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(100)
            .WithMessage("Title must be less than 100 characters");

        RuleFor(x => x.CourseId)
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage("CourseId must be greater than 0");
    }
}