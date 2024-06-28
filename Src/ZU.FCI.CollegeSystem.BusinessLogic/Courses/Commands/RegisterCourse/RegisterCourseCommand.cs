using FluentResults;
using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.CQRS.Commands;
using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.Errors;
using ZU.FCI.CollegeSystem.DataAccess.Contracts;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Courses.Repository;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.StudentCourses.Repository;

namespace ZU.FCI.CollegeSystem.BusinessLogic.Courses.Commands.RegisterCourse;

public sealed record RegisterCourseCommand
    (int CourseId, int StudentId) : ICommand;

public sealed class RegisterCourseCommandHandler :
    ICommandHandler<RegisterCourseCommand>
{
    private readonly IStudentCourseRepository _studentCourseRepository;
    private readonly ICourseRepository _courseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterCourseCommandHandler(IStudentCourseRepository studentCourseRepository,
                                        ICourseRepository courseRepository,
                                        IUnitOfWork unitOfWork)
    {
        _studentCourseRepository = studentCourseRepository;
        _courseRepository = courseRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(RegisterCourseCommand request, CancellationToken cancellationToken)
    {
        var checkCourseIsExists = await _courseRepository.CheckIsExits(request.CourseId);
        if (checkCourseIsExists is false)
            return new Result().WithError(new RecordNotFoundError($"Course with #{request.CourseId} Not Found "));

        var checkIsRegistered = await _studentCourseRepository.CheckIsRegistred(request.CourseId, request.StudentId);

        if (checkIsRegistered is true)
            return Result.Fail("Student is already registered in this course");

        _studentCourseRepository.RegisterCourse(request.CourseId, request.StudentId);
        return await _unitOfWork.SaveChangesAsync() == 0 ?
            Result.Fail("Failed to Register Course") :
            Result.Ok();
    }
}