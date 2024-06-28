using FluentResults;
using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.CQRS.Commands;
using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.Errors;
using ZU.FCI.CollegeSystem.DataAccess.Contracts;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Courses;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Courses.Repository;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Departments.Repository;

namespace ZU.FCI.CollegeSystem.BusinessLogic.Courses.Commands.InsertCourse;

public sealed class InsertCourseHandler : ICommandHandler<InsertCourseCommand>
{
    private readonly ICourseRepository _courseRepository;
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public InsertCourseHandler(ICourseRepository courseRepository, IUnitOfWork unitOfWork, IDepartmentRepository departmentRepository)
    {
        _courseRepository = courseRepository;
        _unitOfWork = unitOfWork;
        _departmentRepository = departmentRepository;
    }

    public async Task<Result> Handle(InsertCourseCommand request, CancellationToken cancellationToken)
    {
        var checkCourseIsExists = await _courseRepository.CheckIsExits(request.Name);
        if (checkCourseIsExists)
        {
            return new Result().WithError(new RecordIsAlreadyExists($"Course with {request.Name} is Already Is Exists"));
        }

        var department = await _departmentRepository.GetDepartmentById(request.DepartmentId);

        if (department is null)
        {
            return new Result().WithError(new RecordNotFoundError($"Department with {request.DepartmentId} not found"));
        }

        var course = new Course
        {
            Name = request.Name,
            Level = request.Level,
            Term = request.Term,
            Hours = request.Hours,
            Code = request.Code,
            DepartmentId = request.DepartmentId
        };

        _courseRepository.Insert(course);

        return await _unitOfWork.SaveChangesAsync(cancellationToken) == 0
            ? Result.Fail("Failed to insert course")
            : Result.Ok().WithSuccess("Course inserted successfully");
    }
}
