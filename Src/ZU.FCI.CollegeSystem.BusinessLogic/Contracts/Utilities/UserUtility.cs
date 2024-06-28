using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ZU.FCI.CollegeSystem.BusinessLogic.Contracts.Utilities;

public class UserUtility
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserUtility(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public int? GetUserId()
    {
        var claims = ClaimTypes.NameIdentifier;
        var userId = _httpContextAccessor.HttpContext?.User.FindFirst(claims);
        return int.Parse(userId.Value);
    }
}