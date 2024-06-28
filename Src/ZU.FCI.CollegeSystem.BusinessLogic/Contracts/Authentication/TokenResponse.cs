namespace ZU.FCI.CollegeSystem.BusinessLogic.Contracts.Authentication;

public sealed record TokenResponse
    (string Token, string RefreshToken, DateTime ExpiresAt);