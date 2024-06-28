using Microsoft.AspNetCore.Identity;

namespace ZU.FCI.CollegeSystem.BusinessLogic.Contracts.Extensions;

internal static class IdentityResultExtension
{
    public static List<string> GetErrors(this IdentityResult identityResult)
    {
        List<string> errors = [];

        foreach (var error in identityResult.Errors)
        {
            string formattedError = $"Code: {error.Code} Description: {error.Description}";
            errors.Add(formattedError);
        }
        return errors;
    }
}