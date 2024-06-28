using FluentResults;
using Microsoft.AspNetCore.Identity;
using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.Authentication;
using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.Authentication.Jwt;
using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.CQRS.Commands;
using ZU.FCI.CollegeSystem.BusinessLogic.Contracts.Errors;
using ZU.FCI.CollegeSystem.DataAccess.Entites.Identity.Doctors;
using ZU.FCI.CollegeSystem.DataAccess.Enums;

namespace ZU.FCI.CollegeSystem.BusinessLogic.Authentication.Doctors.Login;

public sealed class DoctorLoginCommandHandler :
    ICommandHandler<DoctorLoginCommand, TokenResponse>
{
    private readonly UserManager<Doctor> _userManager;

    private readonly IJwtProvider _jwtProvider;

    public DoctorLoginCommandHandler(UserManager<Doctor> userManager, IJwtProvider jwtProvider)
    {
        _userManager = userManager;
        _jwtProvider = jwtProvider;
    }

    public async Task<Result<TokenResponse>> Handle(DoctorLoginCommand request, CancellationToken cancellationToken)
    {
        var getDoctor = await _userManager.FindByEmailAsync(request.Email);

        if (getDoctor is null)
            return new Result<TokenResponse>().WithError(new RecordNotFoundError("Doctor not found"));

        var passwordResult = await _userManager.CheckPasswordAsync(getDoctor, request.Password);

        if (!passwordResult)
            return new Result<TokenResponse>().WithError(new PasswordNotCorrect());

        var token = await _jwtProvider.GenerateTokenAsync(getDoctor.Id, nameof(ApplicationRoles.Doctor));

        var refreshToken = await _jwtProvider.GenerateRefreshTokenAsync(token);

        var expiresAt = await _jwtProvider.GetExpiryDateAsync(token);

        return Result.Ok(new TokenResponse(token, refreshToken, expiresAt));
    }
}