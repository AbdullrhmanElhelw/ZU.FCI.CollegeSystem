using FluentResults;
using Microsoft.AspNetCore.Identity;
using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.CQRS.Commands;
using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.Errors;
using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.Extensions;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Core.Departments.Repository;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Identity.Doctors;
using ZU.FCI.CollegeSystem.DataAccess.Enums;

namespace ZU.FCI.CollegeSystem.BusinessLogic.Authentication.Doctors.Register;

public sealed class DoctorRegisterCommandHandler : ICommandHandler<DoctorRegisterCommand>
{
    private readonly UserManager<Doctor> _userManager;
    private readonly IDepartmentRepository _departmentRepository;

    public DoctorRegisterCommandHandler(UserManager<Doctor> userManager, IDepartmentRepository departmentRepository)
    {
        _userManager = userManager;
        _departmentRepository = departmentRepository;
    }

    public async Task<Result> Handle(DoctorRegisterCommand request, CancellationToken cancellationToken)
    {
        var checkDoctorIsExits = await _userManager.FindByEmailAsync(request.Email);

        if (checkDoctorIsExits is not null)
            return new Result().WithError(new RecordIsAlreadyExists("Doctor already exists"));

        var department = await _departmentRepository.CheckIsExists(request.DepartmentId);

        if (!department)
            return new Result().WithError(new RecordNotFoundError("Department not found"));

        var userName = request.Email.Split('@')[0];

        var doctor = new Doctor
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            UserName = userName,
            PhoneNumber = request.PhoneNumber,
            DepartmentId = request.DepartmentId,
            CreatedOnUtc = DateTime.UtcNow
        };

        var creationResult = await _userManager.CreateAsync(doctor, request.Password);

        if (!creationResult.Succeeded)
            return Result.Fail(creationResult.GetErrors());

        var assignRoleResult = await _userManager.AddToRoleAsync(doctor, nameof(ApplicationRoles.Doctor));

        if (!assignRoleResult.Succeeded)
            return Result.Fail(assignRoleResult.GetErrors());

        return Result.Ok().WithSuccess("Doctor created successfully");
    }
}
