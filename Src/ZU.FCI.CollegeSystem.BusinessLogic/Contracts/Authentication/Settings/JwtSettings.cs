namespace ZU.FCI.CollegeSystem.BusinessLogic.Contracts.Authentication.Settings;

public class JwtSettings
{
    public const string SettingsKey = "Jwt";
    public string Key { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int ExpiryInMinutes { get; set; }
}