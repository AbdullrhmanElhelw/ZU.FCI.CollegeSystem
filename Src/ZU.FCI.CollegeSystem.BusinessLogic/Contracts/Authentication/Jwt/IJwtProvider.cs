namespace ZU.FCI.CollegeSystem.BusinessLogic.Contracts.Authentication.Jwt;

public interface IJwtProvider
{
    Task<string> GenerateTokenAsync(int userId, string role);

    Task<string> GenerateRefreshTokenAsync(string token);

    // genrate method to get the expiry date of the token
    Task<DateTime> GetExpiryDateAsync(string token);
}